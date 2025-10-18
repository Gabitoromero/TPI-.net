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
    }
}
