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

        public PlanService(PlanRepository planRepository)
        {
            _repository = planRepository;
        }
        
        public async Task<List<PlanDTO>> GetAll()
        {
            List<Plan> planes = await _repository.GetAll();
            return planes.Select(p => new PlanDTO 
            { 
                IdPlan = p.IdPlan, 
                Descripcion = p.Descripcion, 
                IdEspecialidad = p.IdEspecialidad
            }).ToList();
        }

        public async Task<PlanDTO> Get(int id)
        {
            Plan plan = await _repository.Get(id);
            if (plan == null)
            {
                return null;
            }

            return new PlanDTO 
            { 
                IdPlan = plan.IdPlan, 
                Descripcion = plan.Descripcion, 
                IdEspecialidad = plan.IdEspecialidad
            };
        }

        public async Task<PlanDTO> Add(PlanDTO dto)
        {
            try
            {
                Plan newplan = new Plan(0, dto.Descripcion, dto.IdEspecialidad);
                await _repository.Add(newplan);
                dto.IdPlan = newplan.IdPlan;
                return dto;
            }
            catch(ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public async Task<bool> Update(PlanDTO dto)
        {
            try
            {
                Plan planToUpdate = new Plan(dto.IdPlan, dto.Descripcion, dto.IdEspecialidad);
                return await _repository.Update(planToUpdate);
            }
            catch(ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _repository.Delete(id);
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
    }
}
