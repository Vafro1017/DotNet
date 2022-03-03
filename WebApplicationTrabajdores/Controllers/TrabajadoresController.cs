using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationTrabajdores.Entidades;

namespace WebApplicationTrabajdores.Controllers
{
    [ApiController]
    [Route("api/trabajdores")]
    public class TrabajadoresController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public TrabajadoresController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }


        [HttpGet]
        [HttpGet("listado")]
        [HttpGet("/listado")]
        public async Task<ActionResult<List<Trabajador>>> Get()
        {
            return await dbContext.Trabajadores.Include(x => x.sucursales).ToListAsync();
        }

        [HttpGet("primero")]
        public async Task<ActionResult<Trabajador>> PrimerTrabajdor([FromHeader]int v,
        [FromQuery] string trabajador, [FromQuery] int trabajadorId)
        {
            return await dbContext.Trabajadores.FirstOrDefaultAsync();
        }

        [HttpGet("{id:int}/{param?}")]
        public async Task<ActionResult<Trabajador>> Get(int id, string param)
        {
            var trabajador = await dbContext.Trabajadores.FirstOrDefaultAsync(x=> x.Id == id);
            

            if (trabajador == null)
            {
                return NotFound();
            }

            return trabajador;
        }


        [HttpGet("{nombre}")]
        public async Task<ActionResult<Trabajador>> Get([FromRoute] string nombre)
        {
            var trabajador = await dbContext.Trabajadores.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));


            if (trabajador == null)
            {
                return NotFound();
            }

            return Ok(trabajador);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Trabajador trabajador)
        {
            dbContext.Add(trabajador);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Trabajador trabajador, int id)
        {
            if (trabajador.Id != id)
            {
                return BadRequest("El ID del alumno no coincide con el establecido en la url");
            }
            dbContext.Update(trabajador);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Trabajadores.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Trabajador()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();

        }

    }
}
