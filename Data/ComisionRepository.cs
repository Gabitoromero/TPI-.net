using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ComisionRepository
    {
        private readonly AcademiaContext _context;
        public ComisionRepository(AcademiaContext context)
        {
            _context = context;
        }

        public async Task<Comision?> Get(int id) => await _context.Comisiones.FirstOrDefaultAsync(c => c.Id_comision == id);
        public async Task<List<Comision>> GetAll() => await _context.Comisiones.ToListAsync();

        public async Task Add(Comision comision)
        {
            try
            {
                await _context.Comisiones.AddAsync(comision);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public async Task<bool> Update(Comision comision)
        {
            try
            {
                Comision? existing = await _context.Comisiones.FindAsync(comision.Id_comision);
                if (existing == null) return false;
                existing.Desc_comision = comision.Desc_comision;
                existing.Anio_especialidad = comision.Anio_especialidad;
                existing.Id_plan = comision.Id_plan;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            Comision? existing = await _context.Comisiones.FindAsync(id);
            if (existing == null) return false;
            _context.Comisiones.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
