using Joseco.DDD.Core.Results;
using MediatR;
using PlanesRecetas.domain.Care;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.infraestructure.Care
{
    public sealed class GetAllCategoriasQueryHandler
        : IRequestHandler<GetAllCategoriasQuery, Result<List<Categoria>>>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public GetAllCategoriasQueryHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public Task<Result<List<Categoria>>> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
        {
            var categorias = _categoriaRepository.GetAll();

            if (categorias == null || categorias.Count == 0)
                return Task.FromResult(Result.Failure<List<Categoria>>(Error.None));

            return Task.FromResult(Result.Success(categorias));
        }
    }
}
