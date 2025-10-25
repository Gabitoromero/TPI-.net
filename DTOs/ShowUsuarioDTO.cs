using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
     public class ShowUsuarioDTO
     {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Tipo { get; set; }

        public bool? Habilitado{ get; set; }
        public int Legajo { get; set; }

    }
}
