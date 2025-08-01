namespace DTOs.UsuarioDTOs
{   
    public class FullUsuarioDTO 
    {
        public int Id { get; set; }
        public bool Habilitado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaAlta { get; set; }

    }
    
}
