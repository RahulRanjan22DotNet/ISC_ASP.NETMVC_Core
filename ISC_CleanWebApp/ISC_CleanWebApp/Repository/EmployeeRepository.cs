using ISC_CleanWebApp.Data;
using ISC_CleanWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ISC_CleanWebApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext= employeeDbContext;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            employeeDbContext.Employees.Add(employee);
            await employeeDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = new Employee();
            employee = await employeeDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            employeeDbContext.Employees.Remove(employee);
            await employeeDbContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            var employeeList = new List<Employee>();
            employeeList = await employeeDbContext.Employees.ToListAsync();
            return employeeList;
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            var employee = new Employee();
            employee = await employeeDbContext.Employees.FirstOrDefaultAsync(x=> x.Id == id);
            return employee;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            employeeDbContext.Employees.Update(employee);
            await employeeDbContext.SaveChangesAsync();
        }
    }
}
