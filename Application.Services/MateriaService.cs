using Data;
using DTOs;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MateriaService
    {
        private readonly MateriaRepository _repository;
        
        public MateriaService(MateriaRepository repo)
        {
            _repository = repo;
        }

        public async Task<MateriaDTO?> Get(int id)
        {
            Materia m = await _repository.Get(id);
            if (m == null) return null;
            return new MateriaDTO
            {
                Id_materia = m.Id_materia,
                Desc_materia = m.Desc_materia,
                Hs_semanales = m.Hs_semanales,
                Hs_totales = m.Hs_totales,
                Id_plan = m.Id_plan
            };
        }

        public async Task<List<MateriaDTO>> GetAll()
        {
            return (await _repository.GetAll()).Select(m => new MateriaDTO
            {
                Id_materia = m.Id_materia,
                Desc_materia = m.Desc_materia,
                Hs_semanales = m.Hs_semanales,
                Hs_totales = m.Hs_totales,
                Id_plan = m.Id_plan
            }).ToList();
        }

        public async Task<MateriaDTO> Add(MateriaDTO dto)
        {
            Materia m = new Materia
            {
                Id_materia = 0,
                Desc_materia = dto.Desc_materia,
                Hs_semanales = dto.Hs_semanales,
                Hs_totales = dto.Hs_totales,
                Id_plan = dto.Id_plan
            };
            await _repository.Add(m);
            dto.Id_materia = m.Id_materia;
            return dto;
        }

        public async Task<bool> Update(MateriaDTO dto)
        {
            try
            {
                Materia m = new Materia
                {
                    Id_materia = dto.Id_materia,
                    Desc_materia = dto.Desc_materia,
                    Hs_semanales = dto.Hs_semanales,
                    Hs_totales = dto.Hs_totales,
                    Id_plan = dto.Id_plan
                };
                return await _repository.Update(m);
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
    }
}
