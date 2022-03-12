﻿using Employee.Application.DTO;
using MediatR;

namespace Employee.Application.Commands
{
    public class CreateEmployeeCommand : IRequest<EmployeeDTO>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
