using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    internal class Usuario
    {
        //Fields
        string _Apellido;
        string _Clave;
        string _Email;
        string _Habilitado;
        string _Nombre;
        string _NombreUsaurio;

        //properties
        public string Apellido { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public bool Habilitado { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }



    }

}
