using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CursoDisplayDTO
    {
        
        public int IdCurso { get; set; }
        public string Materia { get; set; }
        public string Comision { get; set; }
        public int Anio { get; set; }
        public string DisplayText { get; set; }
    }
}
