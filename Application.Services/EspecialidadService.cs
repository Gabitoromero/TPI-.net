using Data;
using Domain.Model;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class EspecialidadService
    {
        private readonly PlanRepository planRepository;
        private readonly EspecialidadRepository _repository;

        public EspecialidadService(EspecialidadRepository especialidadRepository, PlanRepository planRepository)
        {
            _repository = especialidadRepository;
            this.planRepository = planRepository;
        }
        public EspecialidadDTO? Get(int id)
        {
            Especialidad? esp = _repository.Get(id);

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

        }
        
        public EspecialidadDTO Add(EspecialidadDTO dto)
        {   
            Especialidad esp = new Especialidad(0, dto.Descripcion); // El 0, al ser el default de int, ef lo ignora si la columna es autogenerada, como por ejemplo el id
            _repository.Add(esp);
            dto.Id = esp.Id; // Entity actualiza el objeto con el Id autogenerado solito, el que creo ef se merece un Nobel 
            return dto;
        }

        public bool Delete(int id) 
        {
            try
            {
                List<Plan> planes = planRepository.GetAll();
                            bool hasPlans = planes.Any(p => p.IdEspecialidad == id);
                            if (hasPlans) throw new InvalidOperationException("No se puede eliminar esta especialidad: tiene planes relacionados.");

                            return _repository.Delete(id);
            }
            catch (InvalidOperationException err)
            {
                throw new ArgumentException(err.Message);
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }

        }

        public bool Update(EspecialidadDTO dto)
        {
            Especialidad esp = new Especialidad(dto.Id, dto.Descripcion);
            return _repository.Update(esp);

        }

           
    }
}
