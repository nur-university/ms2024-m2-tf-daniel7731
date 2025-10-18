using Joseco.DDD.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.domain.Care
{
    public class Receta : AggregateRoot
    {
        public String Nombre { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public Tiempo Tiempo { get; set; }
        public Receta(Guid id, String nombre, List<Ingrediente> ingredientes, Tiempo tiempo):base(id)
        {
            Nombre = nombre;
            Ingredientes = ingredientes;
            Tiempo = tiempo;
            if (Ingredientes == null || Ingredientes.Count == 0)
            {
                throw new ArgumentException("La receta debe tener al menos un ingrediente.");
            }
        }
        public Decimal CalcularCalorias()
        {
            return Ingredientes.Sum(i => i.Calorias);
        }
    }
}
