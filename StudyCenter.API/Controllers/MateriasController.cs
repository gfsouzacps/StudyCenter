﻿using Microsoft.AspNetCore.Mvc;
using StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Dominio.Entidades.ViewModels;
using StudyCenter.Shared.Infraestrutura.Backend.Configurations;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Contexts;
using StudyCenter.Shared.Infraestrutura.Backend.Data.Repositories;

namespace StudyCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly StudyCenterDbContext _context;
        private readonly IMateriasRepository _materiasRepository;
        private readonly ITopicosRepository _topicosRepository;

        public MateriasController(StudyCenterDbContext context, MateriasRepository materiasRepository, TopicosRepository topicosRepository)
        {
            _context = context;
            _materiasRepository = materiasRepository;
            _topicosRepository = topicosRepository;
        }

        [HttpGet]
        [Route("GetMaterias")]
        public async Task<ActionResult<Materias>> GetMaterias()
        {
            var materias = await _materiasRepository.GetAllAsync();
            if (!materias.Any())
            {
                return NotFound();
            }
            return Ok(materias);
        }

        [HttpGet]
        [Route("GetMateriasETopicos")]
        public async Task<ActionResult<MateriasViewModel>> GetMateriasETopicos()
        {
            var materias = await _materiasRepository.GetMateriasETopicosAsync();
            if (!materias.Any())
            {
                return NotFound();
            }
            return Ok(materias);
        }

        [HttpPost]
        [Route("CriarMateria")]
        public async Task<ActionResult<Materias>> CriarMateria(MateriasViewModel materiaViewModel)
        {
            var ultimaMateria = _materiasRepository.GetUltimaMateriaAsync();
            int novoIdMateria = ultimaMateria.Result == null ? 1 : ultimaMateria.Result.IdMateria + 1;

            var novaMateria = new Materias(novoIdMateria, materiaViewModel.NomeMateria);

            var ultimoTopico = await _topicosRepository.GetUltimoTopicoAsync();
            int novoIdTopico = ultimoTopico == null ? 1 : ultimoTopico.IdTopico + 1;

            foreach (var topicoViewModel in materiaViewModel.Topicos)
            {
                var novoTopico = new Topicos(novoIdTopico++, topicoViewModel.NomeTopico, novoIdMateria);

                novaMateria.Topicos.Add(novoTopico);
            }

            _context.Materia.Add(novaMateria);
            await _context.SaveChangesAsync();

            var json = JsonHelper.SerializeToJson(novaMateria);

            return CreatedAtAction(nameof(CriarMateria), new { id = novaMateria.IdMateria }, json);
        }

        [HttpDelete]
        [Route("DeletarMateria")]
        public async Task<ActionResult<Materias>> DeletarMateria(int idMateria)
        {
            var materia = await _context.Materia.FindAsync(idMateria);
            if (materia == null)
            {
                return NotFound();
            }

            _context.Materia.Remove(materia);
            await _context.SaveChangesAsync();

            return Ok("Matéria deletada");
        }
    }
}
