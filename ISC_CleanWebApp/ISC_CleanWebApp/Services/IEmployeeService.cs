using ISC_CleanWebApp.DTO;

namespace ISC_CleanWebApp.Services
{
    public interface IEmployeeService 
    {
        public Task<List<EmployeeDTO>> GetAllAsync();
        public Task<EmployeeDTO> GetByIdAsync(int id);
        public Task AddAsync (EmployeeDTO entity);
        public Task UpdateAsync (EmployeeDTO entity);
        public Task DeleteAsync (int id);
    }
}
