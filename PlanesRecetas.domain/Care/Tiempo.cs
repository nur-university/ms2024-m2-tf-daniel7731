using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.domain.Care
{
    public class Tiempo
    {
        public int Id { get; private set; }     // Identity
        public string Nombre { get; private set; }

        private Tiempo() { }
        public Tiempo(string nombre) => Nombre = nombre;
    }
}
