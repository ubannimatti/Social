using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Application.Common.Interfaces;
using Social.Application.Services.Interface;
using Social.Domain.Entities;

namespace Social.Application.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateEmployee(Employee Employee)
        {
            _unitOfWork.Employee.Add(Employee);
            _unitOfWork.Save();
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                Employee? objFromDb = _unitOfWork.Employee.Get(u => u.EmployeeId == id);
                if (objFromDb is not null)
                {
                    _unitOfWork.Employee.Remove(objFromDb);
                    _unitOfWork.Save();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _unitOfWork.Employee.GetAll();
        }

        public Employee GetEmployeeById(int id)
        {
            return _unitOfWork.Employee.Get(u => u.EmployeeId == id, "EmployeeSkills, FamilyMembers");
        }

        public void UpdateEmployee(Employee Employee)
        {
            _unitOfWork.Employee.Update(Employee);
            _unitOfWork.Save();
        }
    }
}
