using Employee.Application.Common.Interface;
using Employee.Core.Entities;

namespace Employee.Application.Interface
{
    public interface IEmployeeRepository : IAsyncRepository<EmployeeModel>
    {
        Task<IEnumerable<EmployeeModel>> GetEmployeeByLastName(string lastname);
    }
}
