using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
        IEmployeeSkillRepository EmployeeSkill { get; }
        ITalukRepository Taluk { get; }
        IFamilyMemberRepository FamilyMember { get; }
        ISkillRepository Skill { get; }
        void Save();
    }
}
