using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Plan
    {
        string _Descripcion;
        int _IdPlan;
        int _IdEspecialidad;

        public string Descripcion { get; set; }
        public int IdPlan { get; set; }
        public int IdEspecialidad { get; set; }

        public Plan(int idPlan, string descripcion, int idEspecialidad)
        {
            IdPlan = idPlan;
            Descripcion = descripcion;
            IdEspecialidad = idEspecialidad;
        }

    }
}
