using Joseco.DDD.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.domain.Care
{
    public interface IRecetaRepository : IRepository<Receta>
    {
        List<Receta> GetAll();
        Task<Receta?> GetByNombreAsync(string nombre);
        Task UpdateAsync(Receta receta);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
