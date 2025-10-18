using Joseco.DDD.Core.Results;
using MediatR;
using PlanesRecetas.domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.application.Pacientes
{
    public class GetPacienteByIdQueryHandler
        : IRequestHandler<GetPacienteByIdQuery, Result<Paciente>>
    {
        private readonly IPacienteRepository _pacienteRepository;

        public GetPacienteByIdQueryHandler(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<Result<Paciente>> Handle(GetPacienteByIdQuery request, CancellationToken cancellationToken)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(request.Id, request.ReadOnly);

            if (paciente is null)
                return Result.Failure<Paciente>(Error.Failure("",$"Paciente with ID '{request.Id}' was not found.",null));

            return Result.Success(paciente);
        }
    }
}
