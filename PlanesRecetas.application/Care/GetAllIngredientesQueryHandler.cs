using Joseco.DDD.Core.Results;
using MediatR;
using PlanesRecetas.domain.Care;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.application.Care
{
    public sealed class GetAllIngredientesQueryHandler
       : IRequestHandler<GetAllIngredientesQuery, Result<List<Ingrediente>>>
    {
        private readonly IIngredienteRepository _ingredienteRepository;

        public GetAllIngredientesQueryHandler(IIngredienteRepository ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        public Task<Result<List<Ingrediente>>> Handle(GetAllIngredientesQuery request, CancellationToken cancellationToken)
        {
            var ingredientes = _ingredienteRepository.GetAll();

            if (ingredientes == null || ingredientes.Count == 0)
                return Task.FromResult(Result.Failure<List<Ingrediente>>(Error.None));

            return Task.FromResult(Result.Success(ingredientes));
        }
    }
}
