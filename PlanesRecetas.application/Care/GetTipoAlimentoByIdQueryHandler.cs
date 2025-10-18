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
    public sealed class GetTipoAlimentoByIdQueryHandler
        : IRequestHandler<GetTipoAlimentoByIdQuery, Result<TipoAlimento>>
    {
        private readonly ITipoAlimentoRepository _repo;

        public GetTipoAlimentoByIdQueryHandler(ITipoAlimentoRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<TipoAlimento>> Handle(GetTipoAlimentoByIdQuery request, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(request.Id);
            if (entity is null)
                return Result.Failure<TipoAlimento>(Error.None);

            return Result.Success(entity);
        }
    }
}
