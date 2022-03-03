using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationTrabajdores.Entidades
{
    public class Trabajador
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 10, ErrorMessage = "el titulo debe tener menos de 10")]
        public string Titulo { get; set; }
        [Required(ErrorMessage ="Se necesita de un nombre para el trabajador")]
        public string Nombre { get; set; } 
        [Range(0,24)]
        [NotMapped]
        public int HoraDeEntrada { get; set; }
        [NotMapped]
        [CreditCard]
        public string Tarjeta { get; set;}
        [NotMapped]
        [Url]
        public string Url { get; set; }
        public List<Sucursal> sucursales { get; set; }
    }
}
