using Joseco.DDD.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.domain.Metrics
{
    public class Unidad : AggregateRoot
    {
        public int Id { get; private set; } // Identity
        public string Nombre { get; private set; }
        public string Simbolo { get; private set; }

        private Unidad() { }
        public Unidad(string nombre, string simbolo)
        {
            Nombre = nombre;
            Simbolo = simbolo;
        }
    }
}
