using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecursoshumanosApiRest.Context;
using RecursoshumanosApiRest.Models;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecursoshumanosApiRest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public PersonasController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IEnumerable<Persona>> Index()
        {
            return await _dataContext.Personas.ToListAsync();
        }


        // GET api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            Persona? persona = await _dataContext.Personas.FindAsync(id);
            
            if(persona == null)
            {
                return NotFound();
            }
            return persona;
        }

        // POST api/Personas
        [HttpPost]
        public async Task<ActionResult<Persona>> Post([FromBody] Persona persona)
        {
            try
            {
                await _dataContext.Personas.AddAsync(persona);
                await _dataContext.SaveChangesAsync();

            }catch(DbException ex){
                return BadRequest(ex.Message);  
            }

            return persona;

        }

        // PUT api/Personas/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Persona persona)
        {
            try
            {
                _dataContext.Entry(persona).State = EntityState.Modified;
                await _dataContext.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                return BadRequest(ex.Message);
            }
            
            return NoContent();

        }

        // DELETE api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Persona? persona = await _dataContext.Personas.FindAsync(id);
            if(persona == null)
            {
                return NotFound();
            }
            _dataContext.Personas.Remove(persona);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
