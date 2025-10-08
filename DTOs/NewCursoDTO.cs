using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class NewCursoDTO
    {
        public int Id_curso { get; set; }
        //public int Id_materia { get; set; }
        //public int Id_comision { get; set; }
        public int Cupo { get; set; }
        public int Anio_calendario { get; set; }
    }
}
