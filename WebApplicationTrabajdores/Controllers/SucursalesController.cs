using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationTrabajdores.Entidades;

namespace WebApplicationTrabajdores.Controllers
{
    [ApiController]
    [Route("sucursales")]
    public class SucursalesController : ControllerBase
    {
        private readonly  ApplicationDbContext dbContext;
        public SucursalesController (ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sucursal>>> GetAll()
        {
            return await dbContext.Sucursales.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Sucursal>> GetById(int id)
        {
            return await dbContext.Sucursales.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Sucursal sucursal)
        {
            var exiteTrab = await dbContext.Trabajadores.AnyAsync(x => x.Id == sucursal.TrabajadorId);

            if (!exiteTrab)
            {
                return BadRequest($"No existe trbajador con la id: {sucursal.TrabajadorId}");
            }

            dbContext.Add(sucursal);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Sucursal sucursal, int id)
        {
            var exit = await dbContext.Sucursales.AnyAsync(x => x.Id == id);

            if (!exit)
            {
                return NotFound("la sucursal especificada no existe");
            }

            if(sucursal.Id == id)
            {
                return BadRequest("el id no existe ");
            }

            dbContext.Update(sucursal);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {    var exit = await dbContext.Sucursales.AnyAsync(x => x.Id == id);

            if (!exit)
            {
                return NotFound("El recurso no fue encontrado");
            }
            dbContext.Remove(new Sucursal { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

}
}
