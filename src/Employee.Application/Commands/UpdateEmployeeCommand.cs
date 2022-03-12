using Employee.Application.DTO;
using MediatR;

namespace Employee.Application.Commands
{
    public class UpdateEmployeeCommand : IRequest<EmployeeDTO>
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
