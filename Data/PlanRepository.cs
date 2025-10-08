using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public class PlanRepository
    {
        private readonly AcademiaContext _context;
        public PlanRepository(AcademiaContext context)
        {
            _context = context;
        }
        public Plan? Get(int id) => _context.Planes.FirstOrDefault(p => p.IdPlan == id);
        public List<Plan> GetAll() => _context.Planes.ToList();
        public bool Update(Plan plan)
        {
            try
            {
                Plan? existingPlan = _context.Planes.Find(plan.IdPlan);
                if (existingPlan != null)
                {
                    //if (!_context.Especialidades.Any(e => e.Id == plan.IdEspecialidad)) throw new ArgumentException($"La especialidad {plan.IdEspecialidad} no existe.");
                    //if (_context.Planes.Any(p => p.Descripcion == plan.Descripcion && p.IdPlan != plan.IdPlan)) throw new ArgumentException($"Ya existe un plan con la descripcion {plan.Descripcion}.");
                    existingPlan.Descripcion = plan.Descripcion;
                    existingPlan.IdEspecialidad = plan.IdEspecialidad;
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
        public void Add(Plan plan)
        {
            if (!_context.Especialidades.Any(e => e.Id == plan.IdEspecialidad)) throw new ArgumentException($"La especialidad {plan.IdEspecialidad} no existe.");
            if (_context.Planes.Any(p => p.Descripcion == plan.Descripcion)) throw new ArgumentException($"Ya existe un plan con la descripcion {plan.Descripcion}.");
            _context.Planes.Add(plan);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {
            Plan? plan = _context.Planes.Find(id);
            if (plan != null)
            {
                _context.Planes.Remove(plan);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
