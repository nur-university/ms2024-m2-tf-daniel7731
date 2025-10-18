using Joseco.DDD.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.domain.Care
{
    public class TipoAlimento : AggregateRoot
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }

        private TipoAlimento() { }
        public TipoAlimento(string nombre) => Nombre = nombre;
    }
}
