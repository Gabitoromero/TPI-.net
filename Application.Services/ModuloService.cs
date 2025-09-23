using System;
using System.Collections.Generic;
using System.Linq;
using DTOs;
using Data;
using Domain.Model;
using System.Data;

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
            try
            {
                Modulo moduloRepe = _repository.GetAll().FirstOrDefault(m => m.Descripcion.ToLower() == dto.Descripcion.ToLower() && m.Id != dto.Id);
                if (moduloRepe != null)
                {
                    throw new ArgumentException("Ya existe un módulo con la misma descripción.");
                }
                Modulo modulo = new Modulo(0, dto.Descripcion);
                _repository.Add(modulo);
                dto.Id = modulo.Id;
                return dto;

            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Error al crear el módulo: " + ex.Message);
            }

        }
        public bool Delete(int id)
        {
           return _repository.Delete(id);
        }

        public ModuloDTO Update(ModuloDTO dto)
        {
            try
            {
                Modulo moduloRepe = _repository.GetAll().FirstOrDefault(m => m.Descripcion.ToLower() == dto.Descripcion.ToLower() && m.Id != dto.Id);
                if (moduloRepe != null)
                {
                    throw new ArgumentException("Ya existe un módulo con la misma descripción.");
                }
                Modulo modulo = new Modulo(dto.Id, dto.Descripcion);
                bool updated = _repository.Update(modulo);
                if (!updated) return null;
                return dto;

            }
            catch(ArgumentException err)
            {
                throw new ArgumentException("Error al actualizar el modulo: " + err.Message);
            }
        }
    }
}
