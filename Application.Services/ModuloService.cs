using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain;
using Domain.Model;
using DTOs;

namespace Application.Services
{
    public class ModuloService
    {
        public ModuloDTO Get(int id)
        {
            Modulo modulo = ModuloInMemory.Modulos.Find(u => u.Id == id);
            if (modulo == null)
            {
                return null;
            }

            ModuloDTO dto = new ModuloDTO { Id = modulo.Id, Descripcion = modulo.Descripcion };
            return dto;
        } //checked

        public List<ModuloDTO> GetAll()
        {
            return ModuloInMemory.Modulos
                .Select(m => new ModuloDTO { Id = m.Id, Descripcion = m.Descripcion })
                .ToList();
        } //checked

        public ModuloDTO Add(NewModuloDTO m)
        {
            if (m.Descripcion == null)
            {
                throw new ArgumentException("Properties non-nulleable are null");
            }

            if (ModuloInMemory.Modulos.Any(u => u.Descripcion.Equals(m.Descripcion, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("This description already exists: " + m.Descripcion);
            }

            int id = GetNextId();
            Modulo newModulo = new Modulo(id, m.Descripcion);
            ModuloDTO moduloDTO = new ModuloDTO { Id = id, Descripcion = m.Descripcion };
            ModuloInMemory.Modulos.Add(newModulo);
            return moduloDTO;
        } //checked

        public ModuloDTO Remove(int id)
        {
            Modulo moduloToDelete = ModuloInMemory.Modulos.Find(u => u.Id == id);

            if (moduloToDelete == null)
            {
                return null;
            }

            ModuloDTO moduloDeletedDTO = new ModuloDTO
            {
                Id = moduloToDelete.Id,
                Descripcion = moduloToDelete.Descripcion
            };

            ModuloInMemory.Modulos.Remove(moduloToDelete);
            return moduloDeletedDTO;
        } //checked

        private int GetNextId()
        {
            if (ModuloInMemory.Modulos.Count > 0)
            {
                return ModuloInMemory.Modulos.Max(u => u.Id) + 1;
            }

            return 1;
        }
    }
}
