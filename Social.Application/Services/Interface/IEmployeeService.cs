using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Domain.Entities;

namespace Social.Application.Services.Interface
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Employee> GetEmployeesByUser(string userName);
        Employee GetEmployeeById(int id);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);
    }
}
