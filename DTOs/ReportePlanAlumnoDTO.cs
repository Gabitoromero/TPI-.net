namespace DTOs
{
    public class ReportePlanAlumnoDTO
    {
        // Información del Alumno
        public int Legajo { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        
        // Información del Plan
        public string NombrePlan { get; set; } = string.Empty;
        public string NombreEspecialidad { get; set; } = string.Empty;
        
        // Estadísticas
        public int TotalMateriasPlan { get; set; }
        public int MateriasAprobadas { get; set; }
        
        // Lista de Materias del Plan
        public List<MateriaPlanAlumnoDTO> Materias { get; set; } = new();
    }
    
    public class MateriaPlanAlumnoDTO
    {
        public string NombreMateria { get; set; } = string.Empty;
        public int HorasSemanales { get; set; }
        public string Condicion { get; set; } = string.Empty; // "Aprobado", "Reprobado", "Cursando", o vacío si pendiente
    }
}
