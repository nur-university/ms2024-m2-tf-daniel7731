using Joseco.DDD.Core.Results;
using MediatR;
using PlanesRecetas.domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.application.Medicos
{
    public class GetAllNutricionistasQueryHandler
        : IRequestHandler<GetAllNutricionistasQuery, Result<List<Nutricionista>>>
    {
        private readonly INutricionistaRepository _nutricionistaRepository;

        public GetAllNutricionistasQueryHandler(INutricionistaRepository nutricionistaRepository)
        {
            _nutricionistaRepository = nutricionistaRepository;
        }

        public Task<Result<List<Nutricionista>>> Handle(GetAllNutricionistasQuery request, CancellationToken cancellationToken)
        {
            var nutricionistas = _nutricionistaRepository.GetAll();

            if (nutricionistas == null || nutricionistas.Count == 0)
                return Task.FromResult(Result.Failure<List<Nutricionista>>(Error.None));

            return Task.FromResult(Result.Success(nutricionistas));
        }
    }
}
