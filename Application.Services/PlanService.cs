using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Data;
using Domain.Model;

namespace Application.Services
{
    public class PlanService
    {
        public List<PlanDTO> GetAll()
        {
            return PlanInMemory.Planes.Select(plan => new PlanDTO
            {
                IdPlan = plan.IdPlan,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad

            }).ToList();
        }

        public PlanDTO Get(int id)
        {
            var plan = PlanInMemory.Planes.Find(p => p.IdPlan == id);
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

        public PlanDTO Add(PlanDTO dto)
        {
            
            int id = GetNextId();
            Plan plan = new Plan(id, dto.Descripcion, dto.IdEspecialidad);

            Plan planEncontrado = PlanInMemory.Planes.Find(p => p.Descripcion.Equals(dto.Descripcion) && p.IdEspecialidad.Equals(dto.IdEspecialidad));

            if (planEncontrado != null)
            {
                throw new ArgumentException("Ya existe un plan con la misma descripción y especialidad: " + dto.Descripcion);
            }

            PlanInMemory.Planes.Add(plan);


            return new PlanDTO
            {
                IdPlan = plan.IdPlan,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad
            };
        }

        private int GetNextId()
        {
            if (PlanInMemory.Planes.Count == 0)
            {
                return 1;
            }
            return PlanInMemory.Planes.Max(p => p.IdPlan) + 1;
        }

        public void Delete(int id)
        {
            var plan = PlanInMemory.Planes.Find(p => p.IdPlan == id);
            if (plan == null)
            {
                throw new ArgumentException("Plan no encontrado: " + id);
            }
            PlanInMemory.Planes.Remove(plan);
        }

        public PlanDTO Update(PlanDTO dto)
        {
            var plan = PlanInMemory.Planes.Find(p => p.IdPlan == dto.IdPlan);

            if (plan == null)
            {
                throw new ArgumentException("Plan no encontrado: " + dto.IdPlan);
            }

            var busqueda = PlanInMemory.Planes.Find(p => p.IdPlan.Equals(dto.IdPlan));

            if (busqueda != null && busqueda.IdPlan != dto.IdPlan) { 
                throw new ArgumentException("Ya existe un plan con el mismo ID: " + dto.IdPlan);
            }

            plan.Descripcion = dto.Descripcion;
            plan.IdEspecialidad = dto.IdEspecialidad;

            return new PlanDTO
            {
                IdPlan = plan.IdPlan,
                Descripcion = plan.Descripcion,
                IdEspecialidad = plan.IdEspecialidad
            };
        }
    }
}
