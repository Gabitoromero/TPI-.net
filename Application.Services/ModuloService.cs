using System;
using System.Collections.Generic;
using System.Linq;
using DTOs;
using Data;

namespace Application.Services
{
    public class ModuloService
    {
        public List<ModuloDTO> GetAll()
        {
            return ModuloInMemory.Modulos.Select(modulo => new ModuloDTO
            {
                Id = modulo.Id,
                Descripcion = modulo.Descripcion
            }).ToList();
        }

        public ModuloDTO Get(int id)
        {
            var modulo = ModuloInMemory.Modulos.FirstOrDefault(m => m.Id == id);
            return modulo == null ? null : new ModuloDTO
            {
                Id = modulo.Id,
                Descripcion = modulo.Descripcion
            };
        }

        public ModuloDTO Add(ModuloDTO dto)
        {
            int id = GetNextId();
            var modulo = new Domain.Model.Modulo(id, dto.Descripcion);
            ModuloInMemory.Modulos.Add(modulo);

            return new ModuloDTO
            {
                Id = modulo.Id,
                Descripcion = modulo.Descripcion
            };
        }

        public void Delete(int id)
        {
            var modulo = ModuloInMemory.Modulos.FirstOrDefault(m => m.Id == id);
            if (modulo == null)
                throw new ArgumentException($"Módulo no encontrado: {id}");

            ModuloInMemory.Modulos.Remove(modulo);
        }

        public ModuloDTO Update(ModuloDTO dto)
        {
            var modulo = ModuloInMemory.Modulos.FirstOrDefault(m => m.Id == dto.Id);

            if (modulo == null)
                throw new ArgumentException($"Módulo no encontrado: {dto.Id}");
            modulo.Descripcion = dto.Descripcion;

            return new ModuloDTO
            {
                Id = modulo.Id,
                Descripcion = modulo.Descripcion
            };
        }

        private int GetNextId()
        {
            return ModuloInMemory.Modulos.Count == 0
                ? 1
                : ModuloInMemory.Modulos.Max(m => m.Id) + 1;
        }
    }
}
