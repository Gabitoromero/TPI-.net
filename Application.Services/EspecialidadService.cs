using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain;
using Domain.Model;
using DTOs.EspecialidadDTOs;

namespace Application.Services
{
    public class EspecialidadService
    {
        public EspecialidadDTO Get(int id)
        {

            Especialidad esp = EspecialidadInMemory.Especialidades.Find(u => u.Id == id);

            if (esp == null)
            {
                return null;
            }

            EspecialidadDTO dto = new EspecialidadDTO(esp.Id, esp.Descripcion);

            return dto;
        }
        public List<EspecialidadDTO> GetAll()
        {
            return EspecialidadInMemory.Especialidades.Select(e => new EspecialidadDTO(e.Id,e.Descripcion)).ToList();

        }
        public EspecialidadDTO Add(NewEspecialidadDTO e)
        {
            if ( e.Descripcion == null)
            {
                throw new ArgumentException("Properties non-nulleable are null");
            }
            if (EspecialidadInMemory.Especialidades.Any(u => u.Descripcion.Equals(e.Descripcion, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("This description alredy exists: " + e.Descripcion);
            }

            int id = GetNextId();

            Especialidad newEspecialidad = new Especialidad(id,e.Descripcion);
            EspecialidadDTO espDTO = new EspecialidadDTO(id, e.Descripcion);

            EspecialidadInMemory.Especialidades.Add(newEspecialidad);
            return espDTO;

        }
        public EspecialidadDTO Remove(int id)
        {
            Especialidad espToDelete = EspecialidadInMemory.Especialidades.Find(u => u.Id == id);

            if (espToDelete == null)
            {
                return null;
            }
            EspecialidadDTO espDeletedDTO = new EspecialidadDTO(espToDelete.Id, espToDelete.Descripcion);
            EspecialidadInMemory.Especialidades.Remove(espToDelete);
            return espDeletedDTO;

        }
        public EspecialidadDTO Patch(int id, EspecialidadDTO dto)
        {
            Especialidad espToUpdate = EspecialidadInMemory.Especialidades.Find(u => u.Id == id);

            if (espToUpdate == null) { return null; }
            if (dto.Id != null) { espToUpdate.Id = dto.Id; }
            if (dto.Descripcion != null) espToUpdate.Descripcion = dto.Descripcion;
            return new EspecialidadDTO(espToUpdate.Id, espToUpdate.Descripcion);
        }
        private int GetNextId()
        {

            if (EspecialidadInMemory.Especialidades.Count > 0)
            {

                return EspecialidadInMemory.Especialidades.Max(u => u.Id) + 1;

            }

            return 1;
        }
    }
}
