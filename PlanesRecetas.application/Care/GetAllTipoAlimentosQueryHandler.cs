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
    public sealed class GetAllTipoAlimentosQueryHandler
        : IRequestHandler<GetAllTipoAlimentosQuery, Result<List<TipoAlimento>>>
    {
        private readonly ITipoAlimentoRepository _repo;

        public GetAllTipoAlimentosQueryHandler(ITipoAlimentoRepository repo)
        {
            _repo = repo;
        }

        public Task<Result<List<TipoAlimento>>> Handle(GetAllTipoAlimentosQuery request, CancellationToken ct)
        {
            var items = _repo.GetAll();
            if (items == null || items.Count == 0)
                return Task.FromResult(Result.Failure<List<TipoAlimento>>(Error.None));

            return Task.FromResult(Result.Success(items));
        }
    }
}
