using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync() => 
            await _repository.GetAllAsync();

        public async Task<Employee?> GetEmployeeByIdAsync(int id) => 
            await _repository.GetByIdAsync(id);

        public async Task CreateEmployeeAsync(Employee employee) => 
            await _repository.AddAsync(employee);

        public async Task UpdateEmployeeAsync(Employee employee) => 
            await _repository.UpdateAsync(employee);

        public async Task DeleteEmployeeAsync(int id) => 
            await _repository.DeleteAsync(id);
    }
}
