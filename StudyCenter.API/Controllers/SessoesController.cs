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
            var sessao = _sessoesQueryRepository.ObterTodosAsync();
            if (!sessao.Result.Any())
            {
                return NotFound();
            }
            return Ok(sessao);
        }

        [HttpPost]
        [Route("CriarSessao")]
        public async Task<ActionResult<Sessoes>> CriarSessao(SessoesViewModel sessaoViewModel)
        {
            var ultimaSessao = _sessoesQueryRepository.ObterUltimaSessaoAsync();
            int novoIdSessao = ultimaSessao.Result == null ? 1 : ultimaSessao.Result.IdSessao + 1;

            var novaSessao = new Sessoes(novoIdSessao, sessaoViewModel.NomeSessao, sessaoViewModel.AnotacaoSessao, sessaoViewModel.DthrInicioSessao, sessaoViewModel.DthrFimSessao);

            foreach (var sessaoTopicosViewModel in sessaoViewModel.SessaoTopicos)
            {
                var ultimaSessaoTopico = await _sessaoTopicosQueryRepository.ObterUltimaSessaoTopicosAsync();
                int novoIdSessaoTopico = ultimaSessao.Result == null ? 1 : ultimaSessaoTopico.IdSessaoTopico + 1;

                var novaSessaoTopico = new SessaoTopicos(novoIdSessaoTopico, novoIdSessao, sessaoTopicosViewModel.IdTopico, sessaoTopicosViewModel.DuracaoEstudo);

                var topico = _topicosQueryRepository.ObterPorIdAsync(novaSessaoTopico.IdTopico);
                if (topico.Result == null)
                {
                    return NotFound("Tópico não encontrado!");
                }
                novaSessao.SessaoTopicos.Add(novaSessaoTopico);

                var ultimaAnotacaoTopico = await _anotacoesTopicosQueryRepository.ObterUltimaAnotacaoTopicoAsync();
                int novoIdAnotacaoTopico = ultimaAnotacaoTopico == null ? 1 : ultimaAnotacaoTopico.IdAnotacaoTopico + 1;

                foreach (var anotacaoTopicoViewModel in sessaoTopicosViewModel.AnotacoesTopicos)
                {

                    var novaAnotacaoTopico = new AnotacoesTopicos(novoIdAnotacaoTopico++, novoIdSessaoTopico, anotacaoTopicoViewModel.Anotacao);
                    novaSessaoTopico.AnotacoesTopicos.Add(novaAnotacaoTopico);
                }
            }

            _context.Sessoes.Add(novaSessao);
            await _context.SaveChangesAsync();

            var json = JsonHelper.SerializeToJson(novaSessao);

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
