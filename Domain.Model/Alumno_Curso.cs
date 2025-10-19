
namespace Domain.Model
{
    public class Alumno_Curso
    {

        private int idInscripcion;
        private int idAlumno;
        private int idCurso;
        private string? condicion;
        private int? nota;
        public int IdInscripcion { get; set; }
        public int IdAlumno { get; set; }
        public int IdCurso { get; set; }
        public string? Condicion { get; set; }
        public int? Nota { get; set; }

        public Alumno_Curso()
        {
        }
    }
}
