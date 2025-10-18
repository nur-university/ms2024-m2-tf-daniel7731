using Joseco.DDD.Core.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.application.Care
{
    public class CreateRecetaCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public List<Guid> IngredientesIds { get; set; }
        public Guid TiempoId { get; set; }
    }
}
