using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ModuloRepository
    {
        private readonly AcademiaContext _context;
        public ModuloRepository(AcademiaContext context)
        {
            _context = context;
        }
        // Implementar métodos CRUD para Modulo
        public Modulo? Get(int id) => _context.Modulos.FirstOrDefault(m => m.Id == id);
        public List<Modulo> GetAll() => _context.Modulos.ToList();
        public bool Update(Modulo modulo)
        {
            Modulo? existingModulo = _context.Modulos.Find(modulo.Id);
            if (existingModulo != null)
            {
                existingModulo.Descripcion = modulo.Descripcion; // Ojo que en realidad deberiamos usar setters especiales que validen los datos
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Add(Modulo modulo)
        {
            _context.Modulos.Add(modulo);
            _context.SaveChanges();
        }
        public bool Delete(int id)
        {
            Modulo? modulo = _context.Modulos.Find(id);
            if (modulo != null)
            {
                _context.Modulos.Remove(modulo);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
