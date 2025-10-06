using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CursoRepository
    {
        readonly AcademiaContext _context;
        public CursoRepository(AcademiaContext context)
        {
            _context = context;
        }
        
        public Curso? Get(int id) => _context.Cursos.FirstOrDefault(c => c.Id_curso == id);
        public List<Curso> GetAll() => _context.Cursos.ToList();
        public void Add(Curso curso)
        {
            try
            {
                _context.Cursos.Add(curso);
                _context.SaveChanges();
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
        public bool Update(Curso curso)
        {
            try
            {
                Curso? cursoToUpdate = _context.Cursos.Find(curso.Id_curso);
                if (cursoToUpdate != null)
                {
                    cursoToUpdate.Anio_calendario = curso.Anio_calendario;
                    cursoToUpdate.Cupo = curso.Cupo;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
        public bool Delete(int id)
        {
            Curso? curso = _context.Cursos.Find(id);
            if(curso != null)
            {
                _context.Cursos.Remove(curso);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
