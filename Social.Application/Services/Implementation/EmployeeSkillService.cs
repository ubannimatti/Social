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
    public class EmployeeSkillService : IEmployeeSkillService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeSkillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateEmployeeSkill(EmployeeSkill employeeSkill)
        {
            _unitOfWork.EmployeeSkill.Add(employeeSkill);
            _unitOfWork.Save();
        }

        public bool DeleteEmployeeSkills(int id)
        {
            try
            {
                IEnumerable<EmployeeSkill> empSkills = _unitOfWork.EmployeeSkill.GetAll(u => u.EmployeeId == id);
                if (empSkills is not null && empSkills.Any())
                {
                    foreach (EmployeeSkill empSkill in empSkills)
                    {
                        _unitOfWork.EmployeeSkill.Remove(empSkill);
                        _unitOfWork.Save();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
