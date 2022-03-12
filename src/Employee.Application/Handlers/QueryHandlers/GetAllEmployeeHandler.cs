using AutoMapper;
using Employee.Application.DTO;
using Employee.Application.Interface;
using Employee.Application.Queries;
using MediatR;

namespace Employee.Application.Handlers.QueryHandlers
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeListQuery, List<EmployeeDTO>>
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;

        public GetAllEmployeeHandler(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> Handle(GetAllEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var employeeList = await _employeeRepo.GetAllAsync();
            return _mapper.Map<List<EmployeeDTO>>(employeeList);
        }
    }
}
