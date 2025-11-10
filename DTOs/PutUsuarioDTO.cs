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
        public int Id { get; set; } 

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string NombreUsuario { get; set; } 

        public string Email { get; set; } 

        public string Clave { get; set; }

        public bool Habilitado { get; set; }

        public int IdPlan { get; set; }
        
        public string Direccion { get; set; }
        
        public string Telefono { get; set; }
        
        public DateTime FechaNacimiento { get; set; }
    }
}
