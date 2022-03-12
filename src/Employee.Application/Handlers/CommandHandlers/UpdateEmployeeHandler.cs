using AutoMapper;
using Employee.Application.Commands;
using Employee.Application.Common.Exception;
using Employee.Application.DTO;
using Employee.Application.Interface;
using Employee.Core.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Employee.Application.Handlers.CommandHandlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDTO>
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateEmployeeCommand> _logger;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepo, IMapper mapper, ILogger<UpdateEmployeeCommand> logger)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EmployeeDTO> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToUpdate = await _employeeRepo.GetByIdAsync(request.EmployeeId);
            if (employeeToUpdate == null)
            {
                throw new NotFoundException(nameof(EmployeeModel), request.EmployeeId);
            }

            _mapper.Map(request, employeeToUpdate, typeof(UpdateEmployeeCommand), typeof(EmployeeModel));

            await _employeeRepo.UpdateAsync(employeeToUpdate);

            var employeeResponse = _mapper.Map<EmployeeDTO>(employeeToUpdate);

            _logger.LogInformation($"Employee {employeeResponse.EmployeeId} is successfully updated.");

            return employeeResponse;
        }
    }
}
