using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repository;
        private readonly IMapper _mapper;

        public AlunoController(IAlunoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.SelectAsync();
                
                return Ok(_mapper.Map<IEnumerable<AlunoDto>>(result));
            } catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var aluno = await _repository.SelectAsync(id);
                if (aluno == null) return NotFound("Aluno não encontrado");

                return Ok(_mapper.Map<AlunoDto>(aluno));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        // GET api/<AlunoController>/Nome
        [HttpGet("{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var aluno = await _repository.SelectAsync(nome);
                if (aluno == null) return BadRequest("Aluno não encontrado");

                return Ok(_mapper.Map<AlunoDto>(aluno));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // POST api/<AlunoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlunoRegistrarDto model)
        {
            try
            {
                var aluno = _mapper.Map<Aluno>(model);
                await _repository.Add(aluno);
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AlunoRegistrarDto model)
        {
            try
            {
                var aluno = _mapper.Map<Aluno>(model);
                var registro = await _repository.Update(aluno);
                if (registro == null) return BadRequest("Aluno não foi atualizado");

                return Ok(aluno);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // DELETE api/<AlunoController>/5
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
