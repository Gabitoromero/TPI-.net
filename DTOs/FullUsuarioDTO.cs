namespace DTOs
{   
    public class FullUsuarioDTO 
    {
        
        public int Id { get; set; } 
        
        public bool Habilitado { get; set; }


        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string NombreUsuario { get; set; }

        public string Email { get; set; }

        public string? Clave { get; set; }

        public DateTime FechaAlta { get; set; }

         //Persona properties (respetamos que los DTOs no tienen que representar directamente las entidades del dominio, evitando hacer una herencia directa)

        public string Direccion { get; set; }

        public string Telefono { get; set; }
        public string Tipo { get; set; }
        public int Legajo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int IdPlan { get; set; }

    }
    
}
