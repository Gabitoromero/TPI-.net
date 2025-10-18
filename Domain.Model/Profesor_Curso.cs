

namespace Domain.Model
{
    public class Profesor_Curso
    {

        private int _idDictado;
        private int _idCurso;
        private int _idProfesor;
        private int _cargo;
        public int IdDictado { get; set; }

        public int IdCurso { get; set; }

        public int IdProfesor { get; set; }

        public int Cargo { get; set; }

        public Profesor_Curso() { 
        }

    }
}
