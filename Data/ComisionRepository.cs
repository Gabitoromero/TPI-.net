using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class ComisionRepository
    {
        private readonly AcademiaContext _context;
        public ComisionRepository(AcademiaContext context)
        {
            _context = context;
        }

        public Comision? Get(int id) => _context.Comisiones.FirstOrDefault(c => c.Id_comision == id);
        public List<Comision> GetAll() => _context.Comisiones.ToList();

        public void Add(Comision comision)
        {
            try
            {
                _context.Comisiones.Add(comision);
                _context.SaveChanges();
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public bool Update(Comision comision)
        {
            try
            {
                Comision? existing = _context.Comisiones.Find(comision.Id_comision);
                if (existing == null) return false;
                existing.Desc_comision = comision.Desc_comision;
                existing.Anio_especialidad = comision.Anio_especialidad;
                existing.Id_plan = comision.Id_plan;
                _context.SaveChanges();
                return true;
            }
            catch(ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public bool Delete(int id)
        {
            Comision? existing = _context.Comisiones.Find(id);
            if (existing == null) return false;
            _context.Comisiones.Remove(existing);
            _context.SaveChanges();
            return true;
        }
    }
}
