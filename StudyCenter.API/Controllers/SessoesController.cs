using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Dominio.Entidades.ViewModels;
using StudyCenter.Shared.Infraestrutura.Backend.Configurations;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCenter.API.Controllers
{
    /// <summary>
    /// Controlador para manipulação de sessões.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SessoesController : ControllerBase
    {
        private readonly StudyCenterDbContext _context;
        private readonly ISessoesQueryRepository _sessoesQueryRepository;
        private readonly ISessoesCommandRepository _sessoesCommandRepository;
        private readonly ISessaoTopicosQueryRepository _sessaoTopicosQueryRepository;
        private readonly IAnotacoesTopicosQueryRepository _anotacoesTopicosQueryRepository;
        private readonly ITopicosQueryRepository _topicosQueryRepository;

        public SessoesController(StudyCenterDbContext context,
            ISessoesQueryRepository sessoesQueryRepository,
            ISessoesCommandRepository sessoesCommandRepository,
            ISessaoTopicosQueryRepository sessaoTopicosQueryRepository,
            IAnotacoesTopicosQueryRepository anotacoesTopicosQueryRepository,
            ITopicosQueryRepository topicosQueryRepository)
        {
            _context = context;
            _sessoesQueryRepository = sessoesQueryRepository;
            _sessoesCommandRepository = sessoesCommandRepository;
            _sessaoTopicosQueryRepository = sessaoTopicosQueryRepository;
            _anotacoesTopicosQueryRepository = anotacoesTopicosQueryRepository;
            _topicosQueryRepository = topicosQueryRepository;
        }

        /// <summary>
        /// Obtém todas as sessões.
        /// </summary>
        /// <returns>Retorna uma lista de sessões.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todas as sessões.")]
        public async Task<ActionResult<IEnumerable<Sessoes>>> GetSessoes()
        {
            var sessoes = await _sessoesQueryRepository.ObterTodosAsync();
            if (!sessoes.Any())
            {
                return NotFound();
            }
            return Ok(sessoes);
        }

        /// <summary>
        /// Cria uma nova sessão.
        /// </summary>
        /// <param name="sessaoViewModel">O modelo de visão da sessão.</param>
        /// <returns>Retorna a sessão criada.</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova sessão.")]
        public async Task<ActionResult<Sessoes>> CriarSessao(SessoesViewModel sessaoViewModel)
        {
            var novaSessao = new Sessoes
            {
                NomeSessao = sessaoViewModel.NomeSessao,
                AnotacaoSessao = sessaoViewModel.AnotacaoSessao,
                DthrInicioSessao = sessaoViewModel.DthrInicioSessao,
                DthrFimSessao = sessaoViewModel.DthrFimSessao
            };

            _context.Sessoes.Add(novaSessao);
            await _context.SaveChangesAsync();

            foreach (var sessaoTopicosViewModel in sessaoViewModel.SessaoTopicos)
            {
                var topico = await _topicosQueryRepository.ObterPorIdAsync(sessaoTopicosViewModel.IdTopico);
                if (topico == null)
                {
                    return NotFound($"Tópico com Id {sessaoTopicosViewModel.IdTopico} não encontrado!");
                }

                var novaSessaoTopico = new SessaoTopicos
                {
                    IdSessao = novaSessao.IdSessao,
                    IdTopico = sessaoTopicosViewModel.IdTopico,
                    DuracaoEstudo = sessaoTopicosViewModel.DuracaoEstudo
                };

                novaSessao.SessaoTopicos.Add(novaSessaoTopico);
                await _context.SaveChangesAsync();

                foreach (var anotacaoTopicoViewModel in sessaoTopicosViewModel.AnotacoesTopicos)
                {
                    var novaAnotacaoTopico = new AnotacoesTopicos
                    {
                        IdSessaoTopico = novaSessaoTopico.IdSessaoTopico,
                        Anotacao = anotacaoTopicoViewModel.Anotacao
                    };

                    novaSessaoTopico.AnotacoesTopicos.Add(novaAnotacaoTopico);
                }
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSessoes), new { id = novaSessao.IdSessao }, novaSessao);
        }

        /// <summary>
        /// Atualiza uma sessão existente.
        /// </summary>
        /// <param name="idSessao">O ID da sessão a ser atualizada.</param>
        /// <param name="sessaoViewModel">O modelo de visão da sessão com os dados atualizados.</param>
        /// <returns>Um IActionResult representando o resultado da operação.</returns>
        [HttpPut("{idSessao}")]
        [SwaggerOperation(Summary = "Atualiza uma sessão existente.")]
        public async Task<IActionResult> UpdateSessao(int idSessao, SessoesViewModel sessaoViewModel)
        {
            if (idSessao != sessaoViewModel.IdSessao)
            {
                return BadRequest();
            }

            var sessaoToUpdate = await _context.Sessoes.Include(s => s.SessaoTopicos)
                                                       .ThenInclude(st => st.AnotacoesTopicos)
                                                       .FirstOrDefaultAsync(s => s.IdSessao == idSessao);

            if (sessaoToUpdate == null)
            {
                return NotFound();
            }

            sessaoToUpdate.NomeSessao = sessaoViewModel.NomeSessao;
            sessaoToUpdate.AnotacaoSessao = sessaoViewModel.AnotacaoSessao;
            sessaoToUpdate.DthrInicioSessao = sessaoViewModel.DthrInicioSessao;
            sessaoToUpdate.DthrFimSessao = sessaoViewModel.DthrFimSessao;

            // Update SessaoTopicos
            sessaoToUpdate.SessaoTopicos.Clear();
            foreach (var sessaoTopicosViewModel in sessaoViewModel.SessaoTopicos)
            {
                var novaSessaoTopico = new SessaoTopicos
                {
                    IdTopico = sessaoTopicosViewModel.IdTopico,
                    DuracaoEstudo = sessaoTopicosViewModel.DuracaoEstudo
                };

                foreach (var anotacaoTopicoViewModel in sessaoTopicosViewModel.AnotacoesTopicos)
                {
                    var novaAnotacaoTopico = new AnotacoesTopicos
                    {
                        IdSessaoTopico = novaSessaoTopico.IdSessaoTopico,
                        Anotacao = anotacaoTopicoViewModel.Anotacao
                    };
                    novaSessaoTopico.AnotacoesTopicos.Add(novaAnotacaoTopico);
                }

                sessaoToUpdate.SessaoTopicos.Add(novaSessaoTopico);
            }

            _context.Entry(sessaoToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deleta uma sessão e todas as entidades relacionadas a ela.
        /// </summary>
        /// <param name="idSessao">O ID da sessão a ser deletada.</param>
        /// <returns>Retorna 200 OK com uma mensagem de sucesso se a exclusão for bem-sucedida, 
        /// 404 Not Found se a sessão não for encontrada, ou 500 Internal Server Error se ocorrer um erro.</returns>
        [HttpDelete("{idSessao}")]
        [SwaggerOperation(Summary = "Deleta uma sessão e todas as entidades relacionadas a ela.")]
        public async Task<IActionResult> DeleteSessao(int idSessao)
        {
            try
            {
                var sessao = await _sessoesQueryRepository.ObterPorIdAsync(idSessao);
                if (sessao == null)
                {
                    return NotFound();
                }

                _sessoesCommandRepository.Remover(sessao);

                return Ok(new { message = "Sessão deletada com sucesso" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar deletar a sessão.");
            }
        }
    }
}

