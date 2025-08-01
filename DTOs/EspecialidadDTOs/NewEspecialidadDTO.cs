using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.EspecialidadDTOs
{
    public  class NewEspecialidadDTO
    {
        public string? Descripcion { set; get; }

        public NewEspecialidadDTO(string d)
        {
            Descripcion = d;
        }
    }
}



