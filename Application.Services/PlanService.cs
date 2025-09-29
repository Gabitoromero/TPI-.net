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
            return  _repository.Delete(id);
        }

        public PlanDTO Update(PlanDTO dto)
        {
            try
            {
                bool updated= _repository.Update(new Plan ( dto.IdPlan, dto.Descripcion, dto.IdEspecialidad ) );
                if (!updated)
                {
                    return null;
                }
                else
                {
                    return dto;
                }
            }
            catch(ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
            
        }
    }
}
