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
    public class GetNutricionistaByIdQueryHandler
       : IRequestHandler<GetNutricionistaByIdQuery, Result<Nutricionista>>
    {
        private readonly INutricionistaRepository _nutricionistaRepository;

        public GetNutricionistaByIdQueryHandler(INutricionistaRepository nutricionistaRepository)
        {
            _nutricionistaRepository = nutricionistaRepository;
        }

        public async Task<Result<Nutricionista>> Handle(GetNutricionistaByIdQuery request, CancellationToken cancellationToken)
        {
            var nutricionista = await _nutricionistaRepository.GetByIdAsync(request.Id, request.ReadOnly);

            if (nutricionista is null)
                return Result.Failure<Nutricionista>(Error.None);

            return Result.Success(nutricionista);
        }
    }
}
