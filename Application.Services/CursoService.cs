using System;
using System.Collections.Generic;
using System.Linq;
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

        public NewCursoDTO? Get(int id)
        {
           Curso curso = _repository.Get(id);
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
        public List<NewCursoDTO> GetAll()
        {
            
            List<Curso> curso = _repository.GetAll();
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
        public List<NewCursoDTO> GetAvailable()
        {
            var cursos = _repository.GetAvailable();
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
        public NewCursoDTO Add(NewCursoDTO curso)
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
                _repository.Add(newCurso);
                curso.Id_curso = newCurso.Id_curso;
                return curso;
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
        public bool Update(NewCursoDTO dto)
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
                return _repository.Update(curso);
                
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
    }
}
