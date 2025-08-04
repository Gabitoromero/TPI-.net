using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class PutUsuarioDTO
    {
        [Display(Order = 1)]
        public int Id { get; set; } //unique identifier
        [Display(Order = 2)]
        public string Nombre { get; set; }
        [Display(Order = 3)]
        public string Apellido { get; set; }
        [Display(Order = 4)]
        public string NombreUsuario { get; set; } //unique identifier
        [Display(Order = 5)]
        public string Email { get; set; } //unique identifier
        [Display(Order = 6)]
        public string Clave { get; set; }
        [Display(Order = 7)]
        public bool Habilitado { get; set; }
    }
}
