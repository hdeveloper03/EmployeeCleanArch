using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Commands
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int EmployeeId { get; set;}
    }
}
