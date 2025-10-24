using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class InscripcionRepository
    {
        private readonly AcademiaContext _context;

        public InscripcionRepository(AcademiaContext context)
        {
            _context = context;
        }

        public async Task<Profesor_Curso?> GetProfesorInsc(int idDictado) => await _context.Profesor_Cursos.FindAsync(idDictado);
        public async Task<List<Profesor_Curso>> GetAllProfesorInsc(int idProfesor) => await _context.Profesor_Cursos.Where(i => i.IdProfesor == idProfesor).ToListAsync();

        public async Task AddProfesorInsc(Profesor_Curso profesor_Curso)
        {

            await _context.Profesor_Cursos.AddAsync(profesor_Curso);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfesorInsc(int idDictado)
        {
            var existing = await _context.Profesor_Cursos.FirstOrDefaultAsync(pc => pc.IdDictado == idDictado);

            if (existing != null)
            {
                _context.Profesor_Cursos.Remove(existing);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("La inscripción no existe");
            }
        }

        public async Task UpdateProfesorInsc(Profesor_Curso profesor_Curso)
        {
            var existing = await _context.Profesor_Cursos.FirstOrDefaultAsync(pc => pc.IdDictado == profesor_Curso.IdDictado);
            if (existing != null)
            {
                existing.IdProfesor = profesor_Curso.IdProfesor;
                existing.IdCurso = profesor_Curso.IdCurso;
                existing.Cargo = profesor_Curso.Cargo;
                await _context.SaveChangesAsync();
            }
        }

        // Inscripciones de alumnos a cursos

        public async Task<List<Alumno_Curso>> GetAllAlumnoInsc(int idAlumno) => await _context.Alumno_Cursos.Where(i => i.IdAlumno == idAlumno).ToListAsync();

        public async Task AddAlumnoInsc(Alumno_Curso alumno_Curso)
        {
            await _context.Alumno_Cursos.AddAsync(alumno_Curso);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAlumnoInsc(int idInscripcion)
        {
            var existing = await _context.Alumno_Cursos.FirstOrDefaultAsync(ac => ac.IdInscripcion == idInscripcion);
            if (existing != null)
            {
                _context.Alumno_Cursos.Remove(existing);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("La inscripción no existe");
            }
        }

        public async Task UpdateAlumnoInsc(Alumno_Curso alumno_Curso)
        {
            var existing = await _context.Alumno_Cursos.FirstOrDefaultAsync(ac => ac.IdInscripcion == alumno_Curso.IdInscripcion);
            if (existing != null)
            {
                existing.IdAlumno = alumno_Curso.IdAlumno;
                existing.IdCurso = alumno_Curso.IdCurso;
                existing.Condicion = alumno_Curso.Condicion;
                existing.Nota = alumno_Curso.Nota;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetAlumnoCountInCurso(int idCurso)
        {
            return await _context.Alumno_Cursos.CountAsync(ac => ac.IdCurso == idCurso);
        }

        public async Task<List<(Alumno_Curso inscripcion, Usuario alumno)>> GetAlumnosByCursoAsync(int idCurso)
        {
            var query = from ac in _context.Alumno_Cursos
                        join u in _context.Usuarios on ac.IdAlumno equals u.Id
                        where ac.IdCurso == idCurso
                        orderby ac.IdInscripcion
                        select new { inscripcion = ac, alumno = u };

            var result = await query.ToListAsync();
            return result.Select(x => (x.inscripcion, x.alumno)).ToList();
        }
    }
}
