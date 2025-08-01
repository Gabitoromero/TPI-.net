using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Modulo
    {
        //Fields
        int _Id;
        string _Descripcion;
        //Properties
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Modulo(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}