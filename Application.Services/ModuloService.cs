using System;
using System.Collections.Generic;
using System.Linq;
using DTOs;
using Data;
using Domain.Model;

namespace Application.Services
{
    public class ModuloService
    {
        private readonly ModuloRepository _repository;
        public ModuloService(ModuloRepository moduloRepository)
        {
            _repository = moduloRepository;
        }
        public List<ModuloDTO> GetAll()
        {
            List<Modulo> modulos = _repository.GetAll();
            return modulos.Select(m => new ModuloDTO
            {
                Id = m.Id,
                Descripcion = m.Descripcion
            }).ToList();
        }

        public ModuloDTO Get(int id)
        {
            Modulo modulo = _repository.Get(id);
            if (modulo == null) return null;
            return new ModuloDTO
            {
                Id = modulo.Id,
                Descripcion = modulo.Descripcion
            };
        }

        public ModuloDTO Add(ModuloDTO dto)
        {
            Modulo modulo = new Modulo(0, dto.Descripcion);
            _repository.Add(modulo);
            dto.Id = modulo.Id; 
            return dto;
        }

        public bool Delete(int id)
        {
           return _repository.Delete(id);
        }

        public ModuloDTO Update(ModuloDTO dto)
        {
            Modulo modulo = new Modulo(dto.Id, dto.Descripcion);
            bool updated = _repository.Update(modulo);
            if (!updated) return null;
            return dto;
        }
    }
}
