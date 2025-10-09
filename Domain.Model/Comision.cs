using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Comision
    {
        public int Id_comision { get; set; }
        public string Desc_comision { get; set; }
        public int Anio_especialidad { get; set; }
        public int Id_plan { get; set; }

        public Comision() { }
        public Comision(int id_comision, string desc_comision, int anio_especialidad, int id_plan)
        {
            Id_comision = id_comision;
            Desc_comision = desc_comision;
            Anio_especialidad = anio_especialidad;
            Id_plan = id_plan;
        }
    }
}
