using AutoMapper;
using Employee.Application.Commands;
using Employee.Application.DTO;
using Employee.Core.Entities;

namespace Employee.Application.Mapping
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeModel, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeModel, CreateEmployeeCommand>().ReverseMap();
            CreateMap<EmployeeModel, UpdateEmployeeCommand>().ReverseMap();
        }
    }
}
