using System.Linq;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class EspecialidadRepository
    {
        private readonly AcademiaContext _context;

        public EspecialidadRepository(AcademiaContext context)
        {
            _context = context;
        }

        public async Task<Especialidad?> Get(int id) => await _context.Especialidades.FirstOrDefaultAsync(e => e.Id == id);
        public async Task<List<Especialidad>> GetAll() => await _context.Especialidades.ToListAsync();

        public async Task<bool> Update(Especialidad esp)
        {
            try
            {
                Especialidad? existingEsp = await _context.Especialidades.FindAsync(esp.Id);

                if (existingEsp != null)
                {
                    existingEsp.Descripcion = esp.Descripcion;
                    existingEsp.Habilitado = esp.Habilitado;
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

        public async Task Add(Especialidad esp)
        {
            try
            {
                await _context.Especialidades.AddAsync(esp);
                await _context.SaveChangesAsync();
            }
            catch(ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
            
        }

        public async Task<bool> Delete(int id)
        {
            Especialidad? especialidad = await _context.Especialidades.FindAsync(id);

            if (especialidad != null)
            {
                especialidad.Habilitado = false;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
