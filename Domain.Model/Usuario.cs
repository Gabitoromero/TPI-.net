using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Model
{
    public class Usuario
    {
        //Fields
        int _Id;
        string _Apellido;
        string _Clave;
        string _Email;
        string _Habilitado;
        string _Nombre;
        string _NombreUsaurio;
        DateTime _FechaAlta;

        //properties
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public bool Habilitado { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }

        public DateTime FechaAlta { get; set; }

        public Usuario(int id, string apellido, string clave, string email, bool habilitado, string nombre, string nombreUsuario, DateTime fechaAlta)
        {
            Id = id;
            Apellido = apellido;
            Clave = clave;
            Email = email;
            Habilitado = habilitado;
            Nombre = nombre;
            NombreUsuario = nombreUsuario;
            FechaAlta = fechaAlta;
        }
        /*
        public Usuario() 
        {
            Id = 0;
            Apellido = "Apellido";
            Clave = "clave";
            Email = "correo@email.com";
            Habilitado = false;
            Nombre = "Nombre";
            NombreUsuario = "NombreUsuario";
            FechaAlta = DateTime.Now;
        }
        */


    }

}
