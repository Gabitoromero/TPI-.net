using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.EspecialidadDTOs
{
    public class EspecialidadDTO
    {
        public int Id { set; get; }
        public string Descripcion { set; get; }

        public EspecialidadDTO(int i, string d) 
        {
            Id = i;
            Descripcion = d;
        }
    }
}
