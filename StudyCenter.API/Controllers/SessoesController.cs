using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using StudyCenter.API.Api.ViewModels;
using StudyCenter.API.Configurations;
using StudyCenter.API.Data.Contexts;
using StudyCenter.API.Data.Repositories;
using StudyCenter.API.Models;

namespace StudyCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessoesController : ControllerBase
    {
        private readonly StudyCenterDbContext _context;
        private readonly ISessoesRepository _sessoesRepository;
        private readonly ISessaoTopicosRepository _sessaoTopicosRepository;
        private readonly IAnotacoesTopicosRepository _anotacoesTopicosRepository;
        private readonly ITopicosRepository _topicosRepository;

        public SessoesController(StudyCenterDbContext context, SessoesRepository sessoesRepository, SessaoTopicosRepository sessaoTopicosRepository,
            AnotacoesTopicosRepository anotacoesTopicosRepository, TopicosRepository topicosRepository)
        {
            _context = context;
            _sessoesRepository = sessoesRepository;
            _sessaoTopicosRepository = sessaoTopicosRepository;
            _anotacoesTopicosRepository = anotacoesTopicosRepository;
            _topicosRepository = topicosRepository;
        }

        [HttpGet]
        [Route("GetSessao")]
        public async Task<ActionResult<Sessoes>> GetSessao()
        {
            var sessao = _sessoesRepository.GetAllAsync();
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
            var ultimaSessao = _sessoesRepository.GetUltimaSessaoAsync();
            int novoIdSessao = ultimaSessao.Result == null ? 1 : ultimaSessao.Result.IdSessao + 1;

            var novaSessao = new Sessoes(novoIdSessao, sessaoViewModel.NomeSessao, sessaoViewModel.AnotacaoSessao, sessaoViewModel.DthrInicioSessao, sessaoViewModel.DthrFimSessao);

            foreach (var sessaoTopicosViewModel in sessaoViewModel.SessaoTopicos)
            {
                var ultimaSessaoTopico = await _sessaoTopicosRepository.GetUltimaSessaoTopicosAsync();
                int novoIdSessaoTopico = ultimaSessao.Result == null ? 1 : ultimaSessaoTopico.IdSessaoTopico + 1;

                var novaSessaoTopico = new SessaoTopicos(novoIdSessaoTopico, novoIdSessao, sessaoTopicosViewModel.IdTopico, sessaoTopicosViewModel.DuracaoEstudo);

                var topico = _topicosRepository.GetByIdAsync(novaSessaoTopico.IdTopico);
                if (topico.Result == null)
                {
                    return NotFound("Tópico não encontrado!");
                }
                novaSessao.SessaoTopicos.Add(novaSessaoTopico);

                var ultimaAnotacaoTopico = await _anotacoesTopicosRepository.GetUltimaAnotacaoTopicoAsync();
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
