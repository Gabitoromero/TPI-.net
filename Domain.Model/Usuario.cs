using System.Security.Cryptography;

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

        public string Salt { get; private set; }

        public DateTime FechaAlta { get; set; }

        public Usuario(int id, string apellido, string clave, string email, bool habilitado, string nombre, string nombreUsuario, DateTime fechaAlta)
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

        public void SetClave(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contraseña no puede ser nula o vacía.", nameof(password));

            if (password.Length < 6)
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.", nameof(password));

            Salt = GenerateSalt();
            Clave = HashPassword(password, Salt);
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
