using Data;
using DTOs;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class MateriaService
    {
        private readonly MateriaRepository _repository;
        public MateriaService(MateriaRepository repo)
        {
            _repository = repo;
        }

        public MateriaDTO? Get(int id)
        {
            Materia m = _repository.Get(id);
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

        public List<MateriaDTO> GetAll()
        {
            return _repository.GetAll().Select(m => new MateriaDTO
            {
                Id_materia = m.Id_materia,
                Desc_materia = m.Desc_materia,
                Hs_semanales = m.Hs_semanales,
                Hs_totales = m.Hs_totales,
                Id_plan = m.Id_plan
            }).ToList();
        }

        public MateriaDTO Add(MateriaDTO dto)
        {
            Materia m = new Materia
            {
                Id_materia = 0,
                Desc_materia = dto.Desc_materia,
                Hs_semanales = dto.Hs_semanales,
                Hs_totales = dto.Hs_totales,
                Id_plan = dto.Id_plan
            };
            _repository.Add(m);
            dto.Id_materia = m.Id_materia;
            return dto;
        }

        public bool Update(MateriaDTO dto)
        {
            Materia m = new Materia
            {
                Id_materia = dto.Id_materia,
                Desc_materia = dto.Desc_materia,
                Hs_semanales = dto.Hs_semanales,
                Hs_totales = dto.Hs_totales,
                Id_plan = dto.Id_plan
            };
            return _repository.Update(m);
        }

        public bool Delete(int id) => _repository.Delete(id);
    }
}
