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
        public ComisionService(ComisionRepository repo)
        {
            _repository = repo;
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
                Id_plan = c.Id_plan
            };
        }

        public async Task<List<ComisionDTO>> GetAll()
        {
            return (await _repository.GetAll()).Select(c => new ComisionDTO
            {
                Id_comision = c.Id_comision,
                Desc_comision = c.Desc_comision,
                Anio_especialidad = c.Anio_especialidad,
                Id_plan = c.Id_plan
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
                    Id_plan = dto.Id_plan
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
                    Id_plan = dto.Id_plan
                };
                return await _repository.Update(c);
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public async Task<bool> Delete(int id) => await _repository.Delete(id);
    }
}
