using Domain.Model;

namespace Data
{
    public class InscripcionRepository
    {
        private readonly AcademiaContext _context;
        public InscripcionRepository(AcademiaContext context)
        {
            _context = context;
        }

        public Profesor_Curso? GetProfesorInsc(int idDictado) => _context.Profesor_Cursos.Find(idDictado);
        public List<Profesor_Curso> GetAllProfesorInsc(int idProfesor) => _context.Profesor_Cursos.Where(i => i.IdProfesor == idProfesor).ToList();

        public void AddProfesorInsc(Profesor_Curso profesor_Curso)
        {

            _context.Profesor_Cursos.Add(profesor_Curso);
            _context.SaveChanges();
        }

        public void DeleteProfesorInsc(int idDictado)
        {
            var existing = _context.Profesor_Cursos.FirstOrDefault(pc => pc.IdDictado == idDictado);

            if (existing != null)
            {
                _context.Profesor_Cursos.Remove(existing);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("La inscripción no existe");
            }
        }

        public void UpdateProfesorInsc(Profesor_Curso profesor_Curso)
        {
            var existing = _context.Profesor_Cursos.FirstOrDefault(pc => pc.IdDictado == profesor_Curso.IdDictado);
            if (existing != null)
            {
                existing.IdProfesor = profesor_Curso.IdProfesor;
                existing.IdCurso = profesor_Curso.IdCurso;
                existing.Cargo = profesor_Curso.Cargo;
                _context.SaveChanges();
            }
        }

        // Inscripciones de alumnos a cursos

        public List<Alumno_Curso> GetAllAlumnoInsc(int idAlumno) => _context.Alumno_Cursos.Where(i => i.IdAlumno == idAlumno).ToList();

        public void AddAlumnoInsc(Alumno_Curso alumno_Curso)
        {
            _context.Alumno_Cursos.Add(alumno_Curso);
            _context.SaveChanges();
        }

        public void DeleteAlumnoInsc(int idInscripcion)
        {
            var existing = _context.Alumno_Cursos.FirstOrDefault(ac => ac.IdInscripcion == idInscripcion);
            if (existing != null)
            {
                _context.Alumno_Cursos.Remove(existing);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("La inscripción no existe");
            }
        }

        public void UpdateAlumnoInsc(Alumno_Curso alumno_Curso)
        {
            var existing = _context.Alumno_Cursos.FirstOrDefault(ac => ac.IdInscripcion == alumno_Curso.IdInscripcion);
            if (existing != null)
            {
                existing.IdAlumno = alumno_Curso.IdAlumno;
                existing.IdCurso = alumno_Curso.IdCurso;
                existing.Condicion = alumno_Curso.Condicion;
                existing.Nota = alumno_Curso.Nota;
                _context.SaveChanges();
            }
        }
    }
}
