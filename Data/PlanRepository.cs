using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PlanRepository
    {
        private readonly AcademiaContext _context;
        public PlanRepository(AcademiaContext context)
        {
            _context = context;
        }
        public async Task<Plan?> Get(int id) => await _context.Planes.FirstOrDefaultAsync(p => p.IdPlan == id);
        public async Task<List<Plan>> GetAll() => await _context.Planes.ToListAsync();
        public async Task<bool> Update(Plan plan)
        {
            try
            {
                Plan? existingPlan = await _context.Planes.FindAsync(plan.IdPlan);
                if (existingPlan != null)
                {
                    //if (!_context.Especialidades.Any(e => e.Id == plan.IdEspecialidad)) throw new ArgumentException($"La especialidad {plan.IdEspecialidad} no existe.");
                    //if (_context.Planes.Any(p => p.Descripcion == plan.Descripcion && p.IdPlan != plan.IdPlan)) throw new ArgumentException($"Ya existe un plan con la descripcion {plan.Descripcion}.");
                    existingPlan.Descripcion = plan.Descripcion;
                    existingPlan.IdEspecialidad = plan.IdEspecialidad;
                    existingPlan.Habilitado = plan.Habilitado;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;

            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
        public async Task Add(Plan plan)
        {
            try
            {
                //if (!_context.Especialidades.Any(e => e.Id == plan.IdEspecialidad)) throw new ArgumentException($"La especialidad {plan.IdEspecialidad} no existe.");
                //if (_context.Planes.Any(p => p.Descripcion == plan.Descripcion)) throw new ArgumentException($"Ya existe un plan con la descripcion {plan.Descripcion}.");
                await _context.Planes.AddAsync(plan);
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException err)
            {
                throw new Exception(err.Message);
            }
            catch (ArgumentException err)
            {
                throw new Exception(err.Message);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

        }
        public async Task<bool> Delete(int id)
        {
            Plan? plan = await _context.Planes.FindAsync(id);
            if (plan != null)
            {
                plan.Habilitado = false;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
