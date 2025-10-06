using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Curso
    {
        int _id_curso;
        //int _id_materia;
        //int _id_comision;
        int _anio_calendario;
        int _cupo;

        public int Id_curso { get; set; }
        //public int Id_materia { get; set; }
        //public int Id_comision { get; set; }
        public int Cupo { get; set; }
        public int Anio_calendario { get; set; }
    }
}
