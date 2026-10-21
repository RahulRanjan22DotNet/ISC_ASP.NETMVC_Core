using ISC_CleanWebApp.DTO;
using ISC_CleanWebApp.Models;
using ISC_CleanWebApp.Repository;

namespace ISC_CleanWebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository _employeeRepository)
        {
            this.employeeRepository = _employeeRepository;
        }
        public async Task AddAsync(EmployeeDTO entity)
        {
            Employee obj = new Employee();
            obj.Id = entity.Id;
            obj.Name = entity.Name;
            obj.Gender = entity.Gender;
            obj.DOB = entity.DOB;
            obj.Mobile = entity.Mobile;
            obj.Email = entity.Email;
            await employeeRepository.AddEmployeeAsync(obj);
        }

        public async Task DeleteAsync(int id)
        {
            await employeeRepository.DeleteEmployeeAsync(id);
        }

        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            var employee = await employeeRepository.GetAllEmployeeAsync();
            return employee.Select(x=>new EmployeeDTO {Id = x.Id, Name = x.Name, 
                Gender = x.Gender, DOB = x.DOB, Email = x.Email, Mobile = x.Mobile}).ToList();
        }

        public async Task<EmployeeDTO> GetByIdAsync(int id)
        {
            var employee = await employeeRepository.GetEmployeeAsync(id);
            return new EmployeeDTO { Id = employee.Id, Name = employee.Name, 
                Gender = employee.Gender, DOB = employee.DOB, Mobile= employee.Mobile, Email= employee.Email};
        }

        public async Task UpdateAsync(EmployeeDTO entity)
        {
            Employee obj = new Employee();
            obj.Id = entity.Id;
            obj.Name = entity.Name;
            obj.Gender = entity.Gender;
            obj.DOB = entity.DOB;
            obj.Mobile = entity.Mobile;
            obj.Email = entity.Email;
            await employeeRepository.UpdateEmployeeAsync(obj);
        }
    }
}
