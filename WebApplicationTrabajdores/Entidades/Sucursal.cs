namespace WebApplicationTrabajdores.Entidades
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int TrabajadorId { get; set; }
        public Trabajador Trabajador { get; set; }
    }
}
