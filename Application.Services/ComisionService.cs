using Data;
using DTOs;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ComisionService
    {
        private readonly ComisionRepository _repository;
        private readonly CursoRepository _cursoRepository;
        public ComisionService(ComisionRepository repo, CursoRepository repoCurso)
        {
            _repository = repo;
            _cursoRepository = repoCurso;
        }

        public async Task<ComisionDTO?> Get(int id)
        {
            Comision c = await _repository.Get(id);
            if (c == null) return null;
            return new ComisionDTO
            {
                Id_comision = c.Id_comision,
                Desc_comision = c.Desc_comision,
                Anio_especialidad = c.Anio_especialidad,
                Id_plan = c.Id_plan,
                Habilitado = c.Habilitado
            };
        }

        public async Task<List<ComisionDTO>> GetAll()
        {
            return (await _repository.GetAll()).Select(c => new ComisionDTO
            {
                Id_comision = c.Id_comision,
                Desc_comision = c.Desc_comision,
                Anio_especialidad = c.Anio_especialidad,
                Id_plan = c.Id_plan,
                Habilitado = c.Habilitado
            }).ToList();
        }

        public async Task<ComisionDTO> Add(ComisionDTO dto)
        {
            try
            {
                Comision c = new Comision
                {
                    Id_comision = 0,
                    Desc_comision = dto.Desc_comision,
                    Anio_especialidad = dto.Anio_especialidad,
                    Id_plan = dto.Id_plan,
                    Habilitado = true
                };
                await _repository.Add(c);
                dto.Id_comision = c.Id_comision;
                return dto;
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public async Task<bool> Update(ComisionDTO dto)
        {
            try
            {
                Comision c = new Comision
                {
                    Id_comision = dto.Id_comision,
                    Desc_comision = dto.Desc_comision,
                    Anio_especialidad = dto.Anio_especialidad,
                    Id_plan = dto.Id_plan,
                    Habilitado = dto.Habilitado
                };
                return await _repository.Update(c);
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            List<Curso> cursos = await _cursoRepository.GetAll();
            List<Curso> cursosComision = cursos.Where(c => c.Id_comision == id).ToList();
            
            foreach (Curso curso in cursosComision)
            {
                await _cursoRepository.Delete(curso.Id_curso);
            }
            
            return await _repository.Delete(id);
        }
    }
}
