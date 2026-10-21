using ISC_CleanWebApp.Models;

namespace ISC_CleanWebApp.Repository
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllEmployeeAsync();

        public Task<Employee> GetEmployeeAsync(int id);

        public Task AddEmployeeAsync(Employee employee);

        public Task UpdateEmployeeAsync(Employee employee);

        public Task DeleteEmployeeAsync(int id);
    }
}
