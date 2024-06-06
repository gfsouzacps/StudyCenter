using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Dominio.Entidades.ViewModels;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;

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
        /// <remarks>
        /// Retorna uma lista de todas as sessões cadastradas no sistema.
        /// </remarks>
        /// <response code="200">Retorna uma lista de todas as sessões.</response>
        /// <response code="404">Se não houver sessões cadastradas.</response>
        [HttpGet]
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
        /// <remarks>
        /// Cria uma nova sessão no sistema com os tópicos relacionados fornecidos.
        /// </remarks>
        /// <param name="sessaoViewModel">Os dados da sessão a ser criada.</param>
        /// <returns>Retorna a sessão criada.</returns>
        /// <response code="201">Retorna a sessão criada.</response>
        /// <response code="404">Se o tópico relacionado não for encontrado.</response>
        /// <response code="500">Se ocorrer um erro ao tentar criar a sessão.</response>
        [HttpPost]
        public async Task<ActionResult<Sessoes>> CriarSessao(SessoesViewModel sessaoViewModel)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar criar a sessão.");
            }
        }

        /// <summary>
        /// Atualiza uma sessão existente.
        /// </summary>
        /// <remarks>
        /// Atualiza uma sessão existente no sistema com os novos dados fornecidos.
        /// </remarks>
        /// <param name="idSessao">O ID da sessão a ser atualizada.</param>
        /// <param name="sessaoViewModel">Os novos dados da sessão.</param>
        /// <returns>Um IActionResult representando o resultado da operação.</returns>
        /// <response code="204">Atualização bem-sucedida.</response>
        /// <response code="400">Se o ID da sessão não corresponder ao ID fornecido.</response>
        /// <response code="404">Se a sessão não for encontrada.</response>
        /// <response code="500">Se ocorrer um erro ao atualizar a sessão.</response>
        [HttpPut("{idSessao}")]
        public async Task<IActionResult> UpdateSessao(int idSessao, SessoesViewModel sessaoViewModel)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar atualizar a sessão.");
            }
        }

        /// <summary>
        /// Deleta uma sessão e todas as entidades relacionadas a ela.
        /// </summary>
        /// <param name="idSessao">O ID da sessão a ser deletada.</param>
        /// <returns>Retorna 200 OK com uma mensagem de sucesso se a exclusão for bem-sucedida, 
        /// 404 Not Found se a sessão não for encontrada, ou 500 Internal Server Error se ocorrer um erro.</returns>
        /// <response code="404">Se a sessão não for encontrada.</response>
        /// <response code="500">Se ocorrer um erro ao deletar a sessão.</response>
        [HttpDelete("{idSessao}")]
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