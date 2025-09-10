using System.Linq;
using Domain.Model;

namespace Data
{
    public class EspecialidadRepository
    {
        private AcademiaContext CreateContext()
        {
            return new AcademiaContext();
        }

        public Especialidad? Get(int id)
        {
            using var context = CreateContext();
            return context.Especialidades.FirstOrDefault(e => e.Id == id);
        }
        public List<Especialidad> GetAll()
        {
            using var context = CreateContext();
            return context.Especialidades.ToList();
        }
        
    }
}
