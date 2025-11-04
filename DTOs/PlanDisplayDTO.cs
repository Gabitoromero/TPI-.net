using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PlanDisplayDTO
    {
        public int IdPlan { get; set; }
        public string Descripcion { get; set; }
        public int IdEspecialidad { get; set; }
        public string EspecialidadDescripcion { get; set; }
    }
}
