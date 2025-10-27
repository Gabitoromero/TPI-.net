namespace DTOs
{
    public class ReporteCursoDTO
    {
        // Información del curso
        public int IdCurso { get; set; }
        public string NombreMateria { get; set; } = string.Empty;
        public string DescripcionComision { get; set; } = string.Empty;
        public int AnioCalendario { get; set; }
        public int CupoTotal { get; set; }
        public int TotalInscriptos { get; set; }
        
        // Estadísticas
        public double PromedioGeneral { get; set; }
        public int TotalAprobados { get; set; }
        public int TotalReprobados { get; set; }
        public int TotalSinNota { get; set; }
        
        // Listas detalladas
        public List<AlumnoCursoDetalleDTO> Alumnos { get; set; } = new();
        public List<ProfesorCursoDetalleDTO> Profesores { get; set; } = new();
        
        // Distribución de notas para el gráfico
        public Dictionary<string, int> DistribucionNotas { get; set; } = new();
        
        // Porcentajes para gráfico de torta
        public double PorcentajeAprobados { get; set; }
        public double PorcentajeReprobados { get; set; }
        public double PorcentajeSinNota { get; set; }
    }
}
