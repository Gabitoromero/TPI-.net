using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Data;
using Domain.Model;
using System.Data;

namespace Application.Services
{
    public class PlanService
    {
        private readonly PlanRepository _repository;
        private readonly MateriaRepository materiaRepository;

        public PlanService(PlanRepository planRepository, MateriaRepository materiaRepository)
        {
            _repository = planRepository;
            this.materiaRepository = materiaRepository;
        }
        public List<PlanDTO> GetAll()
        {
            List<Plan> planes = _repository.GetAll();
            return planes.Select(p => new PlanDTO(p.IdPlan, p.Descripcion, p.IdEspecialidad)).ToList();
        }

        public PlanDTO Get(int id)
        {
            Plan plan = _repository.Get(id);
            if (plan == null)
            {
                return null;
            }

            return new PlanDTO(plan.IdPlan, plan.Descripcion, plan.IdEspecialidad);
        }

        public PlanDTO Add(PlanDTO dto)
        {
            try
            {
                Plan newplan = new Plan ( 0, dto.Descripcion, dto.IdEspecialidad );
                _repository.Add(newplan);
                dto.IdPlan = newplan.IdPlan;
                return dto;
            }catch(ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                List<Materia> materias = materiaRepository.GetAll();
                            bool hasMaterias = materias.Any(m => m.Id_plan == id);
                            if(hasMaterias) throw new InvalidOperationException("No se puede eliminar este plan: tiene materias relacionadas.");
                            return  _repository.Delete(id);
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

        public bool Update(PlanDTO dto)
        {
            try
            {
                return _repository.Update(new Plan ( dto.IdPlan, dto.Descripcion, dto.IdEspecialidad ) );
                
            }
            catch(ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
            
        }
    }
}
