using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PlanDTO
    {
        public int IdPlan { get; set; }
        public string Descripcion { get; set; }
        public int IdEspecialidad { get; set; }
        public PlanDTO() : this(0, "Sin Descripcion", 1) { }

        public PlanDTO(int idplan, string desc, int idesp) {
            IdPlan = idplan;
            Descripcion = desc;
            IdEspecialidad = idesp;
        }
    }
}
