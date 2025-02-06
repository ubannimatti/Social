using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Domain.Entities;

namespace Social.Application.Services.Interface
{
    public interface IEmployeeSkillService
    {
        void CreateEmployeeSkill(EmployeeSkill employeeSkill);
        bool DeleteEmployeeSkills(int id);
    }
}
