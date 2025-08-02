using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class PostUsuarioDTO
    {
        [Display(Order = 1)]
        public string Nombre { get; set; }
        [Display(Order = 2)]
        public string Apellido { get; set; }
        [Display(Order = 3)]
        public string NombreUsuario { get; set; }
        [Display(Order = 4)]
        public string Email { get; set; }
        [Display(Order = 5)]
        public string Clave { get; set; }
        
        
    }
}
