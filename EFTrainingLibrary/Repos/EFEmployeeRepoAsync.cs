using EFTrainingLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTrainingLibrary.Repos
{
    public class EFEmployeeRepoAsync : IEmployeeRepoAsync
    {
        EYTrainingDB2Context ctx = new EYTrainingDB2Context();
        public async Task DeleteEmployeeAsync(int eId)
        {
            Employee emp2del = await GetEmployeeAsync(eId);
            ctx.Employees.Remove(emp2del);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            List<Employee> emps = await ctx.Employees.ToListAsync();
            return emps;
        }

        public async Task<Employee> GetEmployeeAsync(int eId)
        {
            try
            {
                Employee emp = await (from e in ctx.Employees where e.EmpId == eId select e).FirstAsync();
                return emp;
            }
            catch
            {
                throw new TrainingException("No such Employee id");
            }
        }

        public async Task InsertEmployeeAsync(Employee emp)
        {
            await ctx.Employees.AddAsync(emp);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(int eId, Employee emp)
        {
            Employee emp2edit = await GetEmployeeAsync(eId);
            emp2edit.EmpName = emp.EmpName;
            emp2edit.Designation = emp.Designation;
            emp2edit.EmpPhone = emp.EmpPhone;
            emp2edit.EmpEmail = emp.EmpEmail;
            await ctx.SaveChangesAsync();
        }
    }
}
