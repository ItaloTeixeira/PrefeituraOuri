using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ouri.API.Dtos;
using Ouri.Domain;
using Ouri.Repository;

namespace Ouri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly IOuriRepository _repo;
        public readonly IMapper _mapper; 
        public EscolaController(IOuriRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var escolas = await _repo.GetAllEscolaAsync(true);
                var results = _mapper.Map<EscolaDto[]>(escolas);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou{ex.Message}");

            }

        }
        [HttpGet("{EscolaId}")]
        public async Task<IActionResult> Get(int EscolaId)
        {
            try
            {
                var escola = await _repo.GetEscolaAsyncById(EscolaId, true);
                var results = _mapper.Map<EscolaDto>(escola);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");

            }
        }
        [HttpGet("getByName/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var escolas = await _repo.GetAllEscolaAsyncByName(name, true);
                 var results = _mapper.Map<EscolaDto[]>(escolas);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");

            }
        }

        //POST

        [HttpPost]
        public async Task<IActionResult> Post(EscolaDto model)
        {
            try
            {
                var escola = _mapper.Map<Escola>(model);  
                _repo.Add(escola);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/escola/{model.Id}", model);

                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");

            }

            return BadRequest();
        }
        //PUT
        [HttpPut("{EscolaId}")]
        public async Task<IActionResult> Put(int EscolaId, Escola model)
        {
            try
            {
                var escola = await _repo.GetEscolaAsyncById(EscolaId, false);
                if (escola == null)
                {
                    return NotFound();
                }
                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/escola/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }
        //DELETE
        [HttpDelete("{EscolaId}")]
        public async Task<IActionResult> Delete(int EscolaId)
        {
            try
            {
                var escola = await _repo.GetEscolaAsyncById(EscolaId, false);
                if (escola == null)
                {
                    return NotFound();
                }
                _repo.Delete(escola);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

    }



}