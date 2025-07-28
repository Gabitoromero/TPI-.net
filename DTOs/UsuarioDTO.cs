namespace DTOs
{
    public class UsuarioDTO
    {
        public bool Habilitado { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Clave { get; private set; }
        public string Email { get; private set; }
        public DateTime FechaAlta { get; private set; }

    }
}
