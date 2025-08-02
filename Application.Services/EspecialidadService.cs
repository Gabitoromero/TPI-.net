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
    public class EspecialidadService
    {
        public EspecialidadDTO Get(int id)
        {

            Especialidad esp = EspecialidadInMemory.Especialidades.Find(u => u.Id == id);

            if (esp == null)
            {
                return null;
            }

            EspecialidadDTO dto = new EspecialidadDTO { Id = esp.Id, Descripcion = esp.Descripcion };

            return dto;
        } //checked
        public List<EspecialidadDTO> GetAll()
        {
            return EspecialidadInMemory.Especialidades.Select(e => new EspecialidadDTO{ Id = e.Id, Descripcion = e.Descripcion }).ToList();

        } //checked
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

            Especialidad newEsp = new Especialidad(id,e.Descripcion);
            EspecialidadDTO espDTO = new EspecialidadDTO { Id= id, Descripcion= e.Descripcion };
            EspecialidadInMemory.Especialidades.Add(newEsp);
            return espDTO;

        } //checked
        public EspecialidadDTO Remove(int id)
        {
            Especialidad espToDelete = EspecialidadInMemory.Especialidades.Find(u => u.Id == id);

            if (espToDelete == null)
            {
                return null;
            }
            EspecialidadDTO espDeletedDTO = new EspecialidadDTO{ Id = espToDelete.Id, Descripcion = espToDelete.Descripcion };
            EspecialidadInMemory.Especialidades.Remove(espToDelete);
            return espDeletedDTO;

        } //checked
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
