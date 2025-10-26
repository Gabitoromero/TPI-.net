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
        
        public async Task<Curso?> Get(int id) => await _context.Cursos.FirstOrDefaultAsync(c => c.Id_curso == id);
        public async Task<List<Curso>> GetAll() => await _context.Cursos.ToListAsync();
        public async Task Add(Curso curso)
        {
            try
            {
                await _context.Cursos.AddAsync(curso);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
        public async Task<bool> Update(Curso curso)
        {
            try
            {
                //agrego pequeña logica porque no se como hacer que la bd no permita duplicados
                Curso repeated = _context.Cursos.Where(Curso => Curso.Id_curso != curso.Id_curso).FirstOrDefault(c => c.Anio_calendario == curso.Anio_calendario && c.Id_comision == curso.Id_comision && c.Id_materia == curso.Id_materia);
                if (repeated != null) throw new ArgumentException("Ya existe un curso con la misma materia, comision y año calendario.");
                
                Curso? cursoToUpdate = await _context.Cursos.FindAsync(curso.Id_curso);
                if (cursoToUpdate != null)
                {
                    cursoToUpdate.Anio_calendario = curso.Anio_calendario;
                    cursoToUpdate.Cupo = curso.Cupo;
                    cursoToUpdate.Id_comision = curso.Id_comision;
                    cursoToUpdate.Id_materia = curso.Id_materia;
                    cursoToUpdate.Habilitado = curso.Habilitado;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
        public async Task<bool> Delete(int id)
        {
            Curso? curso = await _context.Cursos.FindAsync(id);
            if(curso != null)
            {
                curso.Habilitado = false;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<List<Curso>> GetAvailable()
        {
            var cursos = await _context.Cursos
                .Where(c => _context.Alumno_Cursos.Count(ac => ac.IdCurso == c.Id_curso) < c.Cupo && c.Habilitado).ToListAsync();

            return cursos;
        }
    }
}
