using Microsoft.AspNetCore.Mvc;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Dominio.Entidades.ViewModels;
using StudyCenter.Shared.Infraestrutura.Backend.Configurations;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;

namespace StudyCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessoesController : ControllerBase
    {
        private readonly StudyCenterDbContext _context;
        private readonly ISessoesQueryRepository _sessoesQueryRepository;
        private readonly ISessaoTopicosQueryRepository _sessaoTopicosQueryRepository;
        private readonly IAnotacoesTopicosQueryRepository _anotacoesTopicosQueryRepository;
        private readonly ITopicosQueryRepository _topicosQueryRepository;

        public SessoesController(StudyCenterDbContext context, SessoesQueryRepository sessoesQueryRepository,
            SessaoTopicosQueryRepository sessaoQueryTopicosRepository, AnotacoesTopicosQueryRepository anotacoesTopicosQueryRepository,
            TopicosQueryRepository topicosQueryRepository)
        {
            _context = context;
            _sessoesQueryRepository = sessoesQueryRepository;
            _sessaoTopicosQueryRepository = _sessaoTopicosQueryRepository;
            _anotacoesTopicosQueryRepository = anotacoesTopicosQueryRepository;
            _topicosQueryRepository = topicosQueryRepository;
        }

        [HttpGet]
        [Route("GetSessao")]
        public async Task<ActionResult<Sessoes>> GetSessao()
        {
            var sessao = await _sessoesQueryRepository.ObterTodosAsync();
            if (!sessao.Any())
            {
                return NotFound();
            }
            return Ok(sessao);
        }


        [HttpPost]
        [Route("CriarSessao")]
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
                var novaSessaoTopico = new SessaoTopicos
                {
                    IdTopico = sessaoTopicosViewModel.IdTopico,
                    DuracaoEstudo = sessaoTopicosViewModel.DuracaoEstudo
                };

                var topico = _topicosQueryRepository.ObterPorIdAsync(novaSessaoTopico.IdTopico);
                if (topico.Result == null)
                {
                    return NotFound("Tópico não encontrado!");
                }
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

            return CreatedAtAction(nameof(CriarSessao), new { id = novaSessao.IdSessao }, novaSessao);
        }

        [HttpDelete]
        [Route("DeletarSessao")]
        public async Task<ActionResult<Sessoes>> DeletarSessao(int idSessao)
        {
            var sessao = await _context.Sessoes.FindAsync(idSessao);
            if (sessao == null)
            {
                return NotFound();
            }

            _context.Sessoes.Remove(sessao);
            await _context.SaveChangesAsync();

            return Ok("Sessão deletada");
        }
    }
}
