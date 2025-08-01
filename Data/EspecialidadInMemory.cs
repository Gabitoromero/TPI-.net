using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public class EspecialidadInMemory
    {
        public static List<Especialidad> Especialidades;

        static EspecialidadInMemory()
        {
            Especialidades = new List<Especialidad>()
            {
                new Especialidad(1,"1ra especialidad"),
                new Especialidad(2,"2da especialidad"),
                new Especialidad(3,"3ra especialidad")
            };
        }
        
    }
}
