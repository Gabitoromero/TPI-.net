
namespace DTOs
{
    public class ShowAlumno_CursoDTO
    {
        public int IdInscripcion { get; set; }
        public ShowUsuarioDTO Alumno { get; set; }
        public NewCursoDTO Curso { get; set; }
        public string? Condicion { get; set; }
        public int? Nota { get; set; }
    }
}
