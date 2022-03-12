using Employee.Application.Interface;
using Employee.Core.Entities;
using Employee.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<EmployeeModel>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeeByLastName(string lastname)
        {
            var employeeList = await _dbContext.Employees
                                    .Where(e => e.LastName == lastname)
                                    .ToListAsync();
            return employeeList;
        }
    }
}
