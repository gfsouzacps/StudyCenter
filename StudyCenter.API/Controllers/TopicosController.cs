﻿using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    public class TopicosController : ControllerBase
    {
        private readonly StudyCenterDbContext _context;
        private readonly ITopicosRepository _topicosRepository;

        public TopicosController(StudyCenterDbContext context, TopicosRepository topicosRepository)
        {
            _context = context;
            _topicosRepository = topicosRepository;
        }

        [HttpGet]
        [Route("GetTopicos")]
        public async Task<ActionResult<Topicos>> GetTopicos()
        {
            var topicos = _topicosRepository.GetAllAsync();
            if (!topicos.Result.Any())
            {
                return NotFound();
            }
            return Ok(topicos.Result);
        }

        [HttpPost]
        [Route("CriarTopico")]
        public async Task<ActionResult<Topicos>> CriarTopico(TopicosViewModel topico) // Criar topico atraves da materia
        {
            var ultimoTopico = _topicosRepository.GetUltimoTopicoAsync();
            int novoIdTopico = ultimoTopico.Result == null ? 1 : ultimoTopico.Result.IdTopico + 1;

            var topicos = new Topicos(novoIdTopico, topico.NomeTopico, topico.IdMateria);

            _context.Topicos.Add(topicos);
            await _context.SaveChangesAsync();

            var json = JsonHelper.SerializeToJson(topicos);

            return CreatedAtAction(nameof(CriarTopico), new { id = topico.IdTopico }, topicos);
        }

        [HttpDelete]
        [Route("DeletarTopico")]
        public async Task<ActionResult<Topicos>> DeletarTopico(int idTopico)
        {
            var topico = await _context.Topicos.FindAsync(idTopico);
            if (topico == null)
            {
                return NotFound();
            }

            _context.Topicos.Remove(topico);
            await _context.SaveChangesAsync();

            return Ok("Matéria deletada");
        }
    }
}
