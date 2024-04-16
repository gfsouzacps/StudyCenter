using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyCenter.API.Api.ViewModels;
using StudyCenter.API.Data.Contexts;
using StudyCenter.API.Data.Repositories;
using StudyCenter.API.Models;

namespace StudyCenter.API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessoesController : ControllerBase
    {
        private readonly StudyCenterDbContext _context;
        private readonly ISessoesRepository _sessoesRepository;

        public SessoesController(StudyCenterDbContext context, SessoesRepository sessoesRepository)
        {
            _context = context;
            _sessoesRepository = sessoesRepository;
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
        public async Task<ActionResult<Sessoes>> CriarSessao(SessoesViewModel sessao)
        {
            int novoId = 0;

            var ultimaSessao = _sessoesRepository.GetUltimaSessaoAsync();
            if (ultimaSessao.Result == null)
            {
                novoId = 1;
            }
            else
            {
                novoId = ultimaSessao.Result.IdSessao + 1;
            }

            var sessoes = new Sessoes(novoId, sessao.NomeSessao, sessao.AnotacaoSessao, sessao.DthrInicioSessao, sessao.DthrFimSessao);

            _context.Sessoes.Add(sessoes);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CriarSessao), new { id = sessao.IdSessao }, sessoes);
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
