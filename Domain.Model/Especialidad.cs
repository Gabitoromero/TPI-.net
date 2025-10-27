using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Especialidad(int id, string descripcion)
        {   
            Id = id;
            Descripcion = descripcion;
        }
    }
    
}
