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
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteEmployeeCommand> _logger;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepo, IMapper mapper, ILogger<DeleteEmployeeCommand> logger)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToDelete = await _employeeRepo.GetByIdAsync(request.EmployeeId);
            if (employeeToDelete == null)
            {
                throw new NotFoundException(nameof(EmployeeModel), request.EmployeeId);
            }

            await _employeeRepo.DeleteAsync(employeeToDelete);
            _logger.LogInformation($"Employee {employeeToDelete.EmployeeId} is successfully deleted.");

            return Unit.Value;
        }
    }
}
