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
    }
}
