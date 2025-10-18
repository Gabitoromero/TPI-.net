using System.Security.Cryptography;

namespace Domain.Model
{
    public class Usuario : Persona
    {
        //properties
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string ClaveHash { get; set; }
        public string Email { get; set; }
        public bool Habilitado { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }

        public string Salt { get; private set; }

        public DateTime FechaAlta { get; set; }

        public Usuario(int id, string apellido, string clave, string email, bool habilitado, string nombre, string nombreUsuario, DateTime fechaAlta, 
            string direccion, string telefono, string tipo, int legajo, DateTime fechaNac, int idPlan) : base(direccion, telefono, tipo, legajo, fechaNac, idPlan)
        {
            Id = id;
            Apellido = apellido;
            SetClave(clave);
            Email = email;
            Habilitado = habilitado;
            Nombre = nombre;
            NombreUsuario = nombreUsuario;
            FechaAlta = fechaAlta;
        }

        private Usuario() : base() { } // para ef

        public void SetClave(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contraseña no puede ser nula o vacía.", nameof(password));
            if (password.Length < 6)
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.", nameof(password));


            Salt = GenerateSalt();
            ClaveHash = HashPassword(password, Salt);
        }

        public bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            string hashedInput = HashPassword(password, Salt);
            return ClaveHash == hashedInput;
        }
        private static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            RandomNumberGenerator.Fill(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        private static string HashPassword(string clave, string salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(clave, Convert.FromBase64String(salt), 10000, HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(32);
            return Convert.ToBase64String(hashBytes);
        }

    }

}
