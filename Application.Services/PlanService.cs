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
        public async Task<List<PlanDTO>> GetAll()
        {
            List<Plan> planes = await _repository.GetAll();
            return planes.Select(p => new PlanDTO(p.IdPlan, p.Descripcion, p.IdEspecialidad)).ToList();
        }

        public async Task<PlanDTO> Get(int id)
        {
            Plan plan = await _repository.Get(id);
            if (plan == null)
            {
                return null;
            }

            return new PlanDTO(plan.IdPlan, plan.Descripcion, plan.IdEspecialidad);
        }

        public async Task<PlanDTO> Add(PlanDTO dto)
        {
            try
            {
                Plan newplan = new Plan ( 0, dto.Descripcion, dto.IdEspecialidad );
                await _repository.Add(newplan);
                dto.IdPlan = newplan.IdPlan;
                return dto;
            }catch(ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
            
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                List<Materia> materias = await materiaRepository.GetAll();
                            bool hasMaterias = materias.Any(m => m.Id_plan == id);
                            if(hasMaterias) throw new InvalidOperationException("No se puede eliminar este plan: tiene materias relacionadas.");
                            return  await _repository.Delete(id);
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

        public async Task<bool> Update(PlanDTO dto)
        {
            try
            {
                return await _repository.Update(new Plan ( dto.IdPlan, dto.Descripcion, dto.IdEspecialidad ) );
                
            }
            catch(ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
            
        }
    }
}
