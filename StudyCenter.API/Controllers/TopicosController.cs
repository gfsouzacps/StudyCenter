using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Dominio.Entidades.ViewModels;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCenter.API.Controllers
{
    /// <summary>
    /// Controlador para manipulação de tópicos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TopicosController : ControllerBase
    {
        private readonly StudyCenterDbContext _context;
        private readonly ITopicosQueryRepository _topicosQueryRepository;
        private readonly ITopicosCommandRepository _topicosCommandRepository;

        /// <summary>
        /// Inicializa uma nova instância do controlador TopicosController.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        /// <param name="topicosQueryRepository">O repositório de consulta de tópicos.</param>
        /// <param name="topicosCommandRepository">O repositório de comandos de tópicos.</param>
        public TopicosController(StudyCenterDbContext context, ITopicosQueryRepository topicosQueryRepository, ITopicosCommandRepository topicosCommandRepository)
        {
            _context = context;
            _topicosQueryRepository = topicosQueryRepository;
            _topicosCommandRepository = topicosCommandRepository;
        }

        /// <summary>
        /// Obtém todos os tópicos.
        /// </summary>
        /// <remarks>
        /// Retorna uma lista de todos os tópicos cadastrados no sistema.
        /// </remarks>
        /// <response code="200">Retorna uma lista de todos os tópicos.</response>
        /// <response code="404">Se não houver tópicos cadastrados.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topicos>>> GetTopicos()
        {
            var topicos = await _topicosQueryRepository.ObterTodosAsync();
            if (!topicos.Any())
            {
                return NotFound();
            }
            return Ok(topicos);
        }

        /// <summary>
        /// Cria um novo tópico.
        /// </summary>
        /// <remarks>
        /// Cria um novo tópico no sistema com os dados fornecidos.
        /// </remarks>
        /// <param name="topicoViewModel">Os dados do tópico a ser criado.</param>
        /// <returns>Um IActionResult representando o resultado da operação.</returns>
        /// <response code="201">Retorna o tópico criado.</response>
        /// <response code="500">Se ocorrer um erro interno ao tentar criar o tópico.</response>
        [HttpPost]
        public async Task<ActionResult<Topicos>> CriarTopico(TopicosViewModel topicoViewModel)
        {
            try
            {
                var topico = new Topicos
                {
                    NomeTopico = topicoViewModel.NomeTopico,
                    IdMateria = topicoViewModel.IdMateria
                };

                _context.Topicos.Add(topico);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTopicos), new { id = topico.IdTopico }, topico);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar criar o tópico.");
            }
        }

        /// <summary>
        /// Atualiza um tópico existente.
        /// </summary>
        /// <remarks>
        /// Atualiza um tópico existente no sistema com os novos dados fornecidos.
        /// </remarks>
        /// <param name="idTopico">O ID do tópico a ser atualizado.</param>
        /// <param name="topicoViewModel">Os novos dados do tópico.</param>
        /// <returns>Um IActionResult representando o resultado da operação.</returns>
        /// <response code="204">Atualização bem-sucedida.</response>
        /// <response code="400">Se o ID do tópico não corresponder ao ID fornecido.</response>
        /// <response code="404">Se o tópico não for encontrado.</response>
        /// <response code="500">Se ocorrer um erro interno ao tentar atualizar o tópico.</response>
        [HttpPut("{idTopico}")]
        public async Task<IActionResult> UpdateTopico(int idTopico, TopicosViewModel topicoViewModel)
        {
            try
            {
                if (idTopico != topicoViewModel.IdTopico)
                {
                    return BadRequest();
                }

                var topicoToUpdate = await _context.Topicos.FindAsync(idTopico);

                if (topicoToUpdate == null)
                {
                    return NotFound();
                }

                topicoToUpdate.NomeTopico = topicoViewModel.NomeTopico;
                topicoToUpdate.IdMateria = topicoViewModel.IdMateria;

                _context.Entry(topicoToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar atualizar o tópico.");
            }
        }


        /// <summary>
        /// Deleta um tópico e todas as entidades relacionadas a ele.
        /// </summary>
        /// <remarks>
        /// Deleta um tópico e todas as suas entidades relacionadas do sistema.
        /// </remarks>
        /// <param name="idTopico">O ID do tópico a ser deletado.</param>
        /// <response code="200">Tópico deletado com sucesso.</response>
        /// <response code="404">Se o tópico não for encontrado.</response>
        /// <response code="500">Se ocorrer um erro ao tentar deletar o tópico.</response>
        [HttpDelete("{idTopico}")]
        public async Task<IActionResult> DeleteTopico(int idTopico)
        {
            try
            {
                var topico = await _topicosQueryRepository.ObterPorIdAsync(idTopico);
                if (topico == null)
                {
                    return NotFound();
                }

                _topicosCommandRepository.Remover(topico);

                return Ok(new { message = "Tópico deletado com sucesso" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar deletar o tópico.");
            }
        }
    }
}