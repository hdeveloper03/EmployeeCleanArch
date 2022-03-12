using Employee.Application.DTO;
using MediatR;

namespace Employee.Application.Queries
{
    public class GetAllEmployeeListQuery : IRequest<List<EmployeeDTO>>
    {

    }
}