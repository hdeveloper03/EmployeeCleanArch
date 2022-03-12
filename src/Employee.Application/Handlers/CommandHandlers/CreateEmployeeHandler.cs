using AutoMapper;
using Employee.Application.Commands;
using Employee.Application.DTO;
using Employee.Application.Interface;
using Employee.Core.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Employee.Application.Handlers.CommandHandlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDTO>
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEmployeeCommand> _logger;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepo, IMapper mapper, ILogger<CreateEmployeeCommand> logger)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EmployeeDTO> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = _mapper.Map<EmployeeModel>(request);
            var newEmployee = await _employeeRepo.AddAsync(employeeEntity);
            var employeeResponse = _mapper.Map<EmployeeDTO>(newEmployee);
            _logger.LogInformation($"Employee {employeeResponse.EmployeeId} is successfully added.");
            return employeeResponse;
        }
    }
}
