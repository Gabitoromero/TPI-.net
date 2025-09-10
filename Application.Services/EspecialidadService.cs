using Data;
using Domain.Model;
using DTOs;

namespace Application.Services
{
    public class EspecialidadService
    {
        private readonly EspecialidadRepository _repository;

        public EspecialidadService(EspecialidadRepository especialidadRepository)
        {
            _repository = especialidadRepository;
        }
        public EspecialidadDTO? Get(int id)
        {
            Especialidad esp = _repository.Get(id);

            if (esp == null) return null;
  
            EspecialidadDTO dto = new EspecialidadDTO { Id = esp.Id, Descripcion = esp.Descripcion };

            return dto;
        } 
        public List<EspecialidadDTO> GetAll()
        {
            List<Especialidad> especialidades = _repository.GetAll();

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
