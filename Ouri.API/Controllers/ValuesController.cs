using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ouri.Repository;




namespace Ouri.API.Controllers
{
    [Route("api/[controller]")]//
    [ApiController]

    public class ValuesController : ControllerBase
    {
        public readonly OuriContext _context;

        public ValuesController(OuriContext context)
        {
            _context = context;

        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
                try
                {
                    var result = await _context.Escolas.ToListAsync();//retorna Escolas do DB
                    return Ok(result); 
                }
                catch (System.Exception)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                    
                }
                
           
        }

        private IActionResult StatusCode(Func<int, StatusCodeResult> statusCode)
        {
            throw new NotImplementedException();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
                try
                {
                    var result = await _context.Escolas.FirstOrDefaultAsync(x=> x.Id ==id);//retorna Escolas do DB
                    return Ok(result); 
                }
                catch (System.Exception)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
                    
                }
                
           
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
