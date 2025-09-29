using System.Linq;
using Domain.Model;

namespace Data
{
    public class EspecialidadRepository
    {
        private readonly AcademiaContext _context;

        public EspecialidadRepository(AcademiaContext context)
        {
            _context = context;
        }

        public Especialidad? Get(int id) => _context.Especialidades.FirstOrDefault(e => e.Id == id);
        public List<Especialidad> GetAll() => _context.Especialidades.ToList();

        public bool Update(Especialidad esp)
        {
            try
            {
                Especialidad? existingEsp = _context.Especialidades.Find(esp.Id);

                if (existingEsp != null)
                {
                    existingEsp.Descripcion = esp.Descripcion; // Ojo que en realidad deberiamos usar setters especiales que validen los datos
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

        public void Add(Especialidad esp)
        {
            try
            {
                _context.Especialidades.Add(esp);
                _context.SaveChanges();
            }
            catch(ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
            
        }

        public bool Delete(int id)
        {
            Especialidad? especialidad = _context.Especialidades.Find(id);

            if (especialidad != null) { 
                _context.Especialidades.Remove(especialidad);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
