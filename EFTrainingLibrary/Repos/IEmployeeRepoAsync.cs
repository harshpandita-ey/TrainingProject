using EFTrainingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Repos
{
    public interface IEmployeeRepoAsync
    {
        Task InsertEmployeeAsync(Employee emp);
        Task UpdateEmployeeAsync(int eId, Employee emp);
        Task DeleteEmployeeAsync(int eId);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int eId);
    }
}
