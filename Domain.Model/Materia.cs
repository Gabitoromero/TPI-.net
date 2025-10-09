using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Materia
    {
        public int Id_materia { get; set; }
        public string Desc_materia { get; set; }
        public int Hs_semanales { get; set; }
        public int Hs_totales { get; set; }
        public int Id_plan { get; set; }

        public Materia() { }
        public Materia(int id_materia, string desc_materia, int hs_semanales, int hs_totales, int id_plan)
        {
            Id_materia = id_materia;
            Desc_materia = desc_materia;
            Hs_semanales = hs_semanales;
            Hs_totales = hs_totales;
            Id_plan = id_plan;
        }
    }
}
