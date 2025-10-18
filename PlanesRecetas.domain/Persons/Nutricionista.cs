using Joseco.DDD.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.domain.Persons
{
    public class Nutricionista : AggregateRoot
    {
       
        public String Nombre { get; set; }
        public Nutricionista() { }
        public Nutricionista( string nombre)
        {
          Nombre=nombre;
        }
        public Nutricionista(Guid id , string nombre) : base(id) {
            Nombre = nombre;
        }
    }
}
