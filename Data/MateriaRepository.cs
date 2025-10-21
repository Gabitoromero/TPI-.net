using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MateriaRepository
    {
        private readonly AcademiaContext _context;
        public MateriaRepository(AcademiaContext context)
        {
            _context = context;
        }

        public async Task<Materia?> Get(int id) => await _context.Materias.FirstOrDefaultAsync(m => m.Id_materia == id);
        public async Task<List<Materia>> GetAll() => await _context.Materias.ToListAsync();

        public async Task Add(Materia materia)
        {
            await _context.Materias.AddAsync(materia);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Materia materia)
        {
            Materia? existing = await _context.Materias.FindAsync(materia.Id_materia);
            if (existing == null) return false;
            existing.Desc_materia = materia.Desc_materia;
            existing.Hs_semanales = materia.Hs_semanales;
            existing.Hs_totales = materia.Hs_totales;
            existing.Id_plan = materia.Id_plan;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            Materia? existing = await _context.Materias.FindAsync(id);
            if (existing == null) return false;
            _context.Materias.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
