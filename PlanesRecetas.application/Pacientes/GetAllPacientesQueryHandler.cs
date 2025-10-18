using Joseco.DDD.Core.Results;
using MediatR;
using PlanesRecetas.application.Pacientes.PlanesRecetas.application.Persons;
using PlanesRecetas.domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.application.Pacientes
{
    public class GetAllPacientesQueryHandler
        : IRequestHandler<GetAllPacientesQuery, Result<List<Paciente>>>
    {
        private readonly IPacienteRepository _pacienteRepository;

        public GetAllPacientesQueryHandler(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public Task<Result<List<Paciente>>> Handle(GetAllPacientesQuery request, CancellationToken cancellationToken)
        {
            // Repository GetAll() is synchronous
            var pacientes = _pacienteRepository.GetAll();

            if (pacientes == null || pacientes.Count == 0)
                return Task.FromResult(Result.Failure<List<Paciente>>(Error.None));

            return Task.FromResult(Result.Success(pacientes));
        }
    }
}
