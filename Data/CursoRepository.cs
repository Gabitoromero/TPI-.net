using Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
                //agrego pequeña logica porque no se como hacer que la bd no permita duplicados
                Curso repeated = _context.Cursos.Where(Curso => Curso.Id_curso != curso.Id_curso).FirstOrDefault(c => c.Anio_calendario == curso.Anio_calendario && c.Id_comision == curso.Id_comision && c.Id_materia == curso.Id_materia);
                if (repeated != null) throw new ArgumentException("Ya existe un curso con la misma materia, comision y año calendario.");
                
                Curso? cursoToUpdate = _context.Cursos.Find(curso.Id_curso);
                if (cursoToUpdate != null)
                {
                    cursoToUpdate.Anio_calendario = curso.Anio_calendario;
                    cursoToUpdate.Cupo = curso.Cupo;
                    cursoToUpdate.Id_comision = curso.Id_comision;
                    cursoToUpdate.Id_materia = curso.Id_materia;
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
