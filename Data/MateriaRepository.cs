using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class MateriaRepository
    {
        private readonly AcademiaContext _context;
        public MateriaRepository(AcademiaContext context)
        {
            _context = context;
        }

        public Materia? Get(int id) => _context.Materias.FirstOrDefault(m => m.Id_materia == id);
        public List<Materia> GetAll() => _context.Materias.ToList();

        public void Add(Materia materia)
        {
            _context.Materias.Add(materia);
            _context.SaveChanges();
        }

        public bool Update(Materia materia)
        {
            Materia? existing = _context.Materias.Find(materia.Id_materia);
            if (existing == null) return false;
            existing.Desc_materia = materia.Desc_materia;
            existing.Hs_semanales = materia.Hs_semanales;
            existing.Hs_totales = materia.Hs_totales;
            existing.Id_plan = materia.Id_plan;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Materia? existing = _context.Materias.Find(id);
            if (existing == null) return false;
            _context.Materias.Remove(existing);
            _context.SaveChanges();
            return true;
        }
    }
}
