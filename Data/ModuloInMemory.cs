using System;
using System.Collections.Generic;
using Domain.Model;

namespace Data
{
    public class ModuloInMemory
    {
        public static List<Modulo> Modulos;

        static ModuloInMemory()
        {
            Modulos = new List<Modulo>()
            {
                new Domain.Model.Modulo(1, "Modulo 1"),
                new Domain.Model.Modulo(2, "Modulo 2"),
                new Domain.Model.Modulo(3, "Modulo 3")
            };
        }
    }
}