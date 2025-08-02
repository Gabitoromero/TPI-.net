using System.ComponentModel.DataAnnotations;
namespace DTOs
{   
    public class FullUsuarioDTO 
    {
        [Display(Order = 1)]
        public int Id { get; set; }
        [Display(Order = 7)]
        public bool Habilitado { get; set; }

        [Display(Order = 2)]
        public string Nombre { get; set; }
        [Display(Order = 3)]
        public string Apellido { get; set; }
        [Display(Order = 4)]
        public string NombreUsuario { get; set; }
        [Display(Order = 5)]
        public string Email { get; set; }
        [Display(Order = 6)]
        public string Clave { get; set; }
        [Display(Order = 8)]
        public DateTime FechaAlta { get; set; }

    }
    
}
