using Data;
using Domain.Model;
using DTOs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class EspecialidadService
    {
        private readonly EspecialidadRepository _repository;

        public EspecialidadService(EspecialidadRepository especialidadRepository)
        {
            _repository = especialidadRepository;
        }
        
        public async Task<EspecialidadDTO?> Get(int id)
        {
            var esp = await _repository.Get(id);
            if (esp == null) return null;
  
            return new EspecialidadDTO 
            { 
                Id = esp.Id, 
                Descripcion = esp.Descripcion
            };
        } 
        
        public async Task<List<EspecialidadDTO>> GetAll()
        {
            List<Especialidad> especialidades = await _repository.GetAll();
            return especialidades.Select(e => new EspecialidadDTO
            {
                Id = e.Id,
                Descripcion = e.Descripcion
            }).ToList();
        }
        
        public async Task<EspecialidadDTO> Add(EspecialidadDTO dto)
        {   
            Especialidad esp = new Especialidad(0, dto.Descripcion);
            await _repository.Add(esp);
            dto.Id = esp.Id;
            return dto;
        }

        public async Task<bool> Update(EspecialidadDTO dto)
        {
            try
            {
                Especialidad esp = new Especialidad(dto.Id, dto.Descripcion);
                return await _repository.Update(esp);
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public async Task<bool> Delete(int id) 
        {
            try
            {
                return await _repository.Delete(id);
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
    }
}
