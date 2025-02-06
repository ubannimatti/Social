using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Domain.Entities;

namespace Social.Application.Common.Interfaces
{
    public interface IEmployeeSkillRepository : IRepository<EmployeeSkill>
    {
        void Update(EmployeeSkill entity);
    }
}
