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
            var especialidadRepository = new EspecialidadRepository();
            Especialidad esp = especialidadRepository.Get(id);

            if (esp == null) return null;
          

            EspecialidadDTO dto = new EspecialidadDTO { Id = esp.Id, Descripcion = esp.Descripcion };

            return dto;
        } //checked
        public List<EspecialidadDTO> GetAll()
        {
            var especialidadRepository = new EspecialidadRepository();
            List<Especialidad> especialidades = especialidadRepository.GetAll();

            return especialidades.Select(e => new EspecialidadDTO
            {
                Id = e.Id,
                Descripcion = e.Descripcion,
            }).ToList();

        } //checked
        /* public EspecialidadDTO Add(NewEspecialidadDTO e)
         {
             if ( e.Descripcion == null)
             {
                 throw new ArgumentException("Properties non-nulleable are null");
             }
             if (EspecialidadRepository.Especialidades.Any(u => u.Descripcion.Equals(e.Descripcion, StringComparison.OrdinalIgnoreCase)))
             {
                 throw new ArgumentException("This description alredy exists: " + e.Descripcion);
             }

             int id = GetNextId();

             Especialidad newEsp = new Especialidad(id,e.Descripcion);
             EspecialidadDTO espDTO = new EspecialidadDTO { Id= id, Descripcion= e.Descripcion };
             EspecialidadRepository.Especialidades.Add(newEsp);
             return espDTO;

         } //checked 
         public EspecialidadDTO Remove(int id)
         {
             Especialidad espToDelete = EspecialidadRepository.Especialidades.Find(u => u.Id == id);

             if (espToDelete == null)
             {
                 return null;
             }
             EspecialidadDTO espDeletedDTO = new EspecialidadDTO{ Id = espToDelete.Id, Descripcion = espToDelete.Descripcion };
             EspecialidadRepository.Especialidades.Remove(espToDelete);
             return espDeletedDTO;

         } //checked
         private int GetNextId()
         {

             if (EspecialidadRepository.Especialidades.Count > 0)
             {

                 return EspecialidadRepository.Especialidades.Max(u => u.Id) + 1;

             }

             return 1;
         }
        */
    }
}
