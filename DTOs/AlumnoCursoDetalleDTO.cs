namespace DTOs
{
    public class AlumnoCursoDetalleDTO
    {
        public int IdInscripcion { get; set; }
        public int Legajo { get; set; }
        public string Alumno { get; set; }
        public string Condicion { get; set; }
        public int? Nota { get; set; }
    }
}
