using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joseco.DDD.Core.Abstractions;
using PlanesRecetas.domain.Metrics;
namespace PlanesRecetas.domain.Care
{
    public class Ingrediente : AggregateRoot
    {
        public Decimal Calorias { get; set; }
        public String Nombre { get; set; }  
        public Categoria Categoria { get; set; }    

        public Decimal CantidadValor { get; set; }
        public Unidad Unidad { get; set; }
        public Ingrediente(Guid id, decimal calorias, string nombre, Categoria categoria, Unidad unidad):base(id)
        {
            Calorias = calorias;
            Nombre = nombre;
            Categoria = categoria;
            Unidad = unidad;
        }
    }
}
