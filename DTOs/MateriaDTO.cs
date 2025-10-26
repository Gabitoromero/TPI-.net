using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MateriaDTO
    {
        public int Id_materia { get; set; }
        public string Desc_materia { get; set; }
        public int Hs_semanales { get; set; }
        public int Hs_totales { get; set; }
        public int Id_plan { get; set; }
        public bool Habilitado { get; set; }
    }
}
