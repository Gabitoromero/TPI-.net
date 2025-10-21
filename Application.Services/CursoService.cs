using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain.Model;
using DTOs;

namespace Application.Services
{
    public class CursoService
    {
        private readonly CursoRepository _repository;

        public CursoService(CursoRepository cursoRepository, InscripcionRepository inscRepository)
        {
            _repository = cursoRepository;
        }

        public async Task<NewCursoDTO?> Get(int id)
        {
           Curso curso = await _repository.Get(id);
            if (curso == null) return null;
            return new NewCursoDTO
            {
                Id_curso = curso.Id_curso,
                Anio_calendario = curso.Anio_calendario,
                Cupo = curso.Cupo,
                Id_materia = curso.Id_materia,
                Id_comision = curso.Id_comision
            };
        }
        public async Task<List<NewCursoDTO>> GetAll()
        {
            
            List<Curso> curso = await _repository.GetAll();
            if (curso == null) return null;
            return curso.Select(m=> new NewCursoDTO
            {
                Id_curso = m.Id_curso,
                Anio_calendario = m.Anio_calendario,
                Cupo = m.Cupo,
                Id_materia = m.Id_materia,
                Id_comision = m.Id_comision
            }).ToList();
        }
        public async Task<List<NewCursoDTO>> GetAvailable()
        {
            var cursos = await _repository.GetAvailable();
            if (cursos == null) return new List<NewCursoDTO>();
            return cursos.Select(m => new NewCursoDTO
            {
                Id_curso = m.Id_curso,
                Anio_calendario = m.Anio_calendario,
                Cupo = m.Cupo,
                Id_materia = m.Id_materia,
                Id_comision = m.Id_comision
            }).ToList();
        }
        public async Task<NewCursoDTO> Add(NewCursoDTO curso)
        {
            try
            {
                Curso newCurso = new Curso
                {
                    Id_curso = 0,
                    Anio_calendario = curso.Anio_calendario,
                    Cupo = curso.Cupo,
                    Id_materia = curso.Id_materia,
                    Id_comision = curso.Id_comision
                };
                await _repository.Add(newCurso);
                curso.Id_curso = newCurso.Id_curso;
                return curso;
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }
        public async Task<bool> Update(NewCursoDTO dto)
        {
            try
            {
                Curso curso = new Curso
                {
                    Id_curso = dto.Id_curso,
                    Anio_calendario = dto.Anio_calendario,
                    Cupo = dto.Cupo,
                    Id_materia = dto.Id_materia,
                    Id_comision = dto.Id_comision
                };
                return await _repository.Update(curso);
                
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
    }
}
