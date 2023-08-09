using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;
using System.Net;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _repository;

        public ProfessorController(IProfessorRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _repository.SelectAsync());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var professor = await _repository.SelectAsync(id);
                if (professor == null) return NotFound("Professor não encontrado");

                return Ok(professor);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        // GET api/<ProfessorController>/Nome
        [HttpGet("{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var professor = await _repository.SelectAsync(nome);
                if (professor == null) return BadRequest("Professor não encontrado");

                return Ok(professor);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Professor professor)
        {
            try
            {
                await _repository.Add(professor);
                return Ok(professor);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Professor professor)
        {
            try
            {
                var registro = await _repository.Update(professor);
                if (registro == null) return BadRequest("Professor não foi atualizado");

                return Ok(professor);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _repository.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
