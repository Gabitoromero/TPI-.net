using Domain.Model;

namespace Data
{
    public class UsuarioInMemory
    {
        public static List<Usuario> Usuarios;

        static UsuarioInMemory() {

            Usuarios = new List<Usuario>
            {
                new Usuario(1,"Romero", "123", "gt@mail.com", true, "Gabriel", "gabigol", DateTime.Now),
                new Usuario(2, "Lurati", "123", "il@mail.com", true, "Ignacio", "luta", DateTime.Now),
                new Usuario(3, "Rodriguez", "123", "ar@mail.com", false, "Alan", "lalan", DateTime.Now)

            };
        
        }

    }
}
