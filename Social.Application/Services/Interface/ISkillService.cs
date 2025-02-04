using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Domain.Entities;

namespace Social.Application.Services.Interface
{
    public interface ISkillService
    {
        IEnumerable<Skill> GetAllSkills();
        Skill GetSkillById(int id);
        void CreateSkill(Skill skill);
        void UpdateSkill(Skill skill);
        bool DeleteSkill(int id);
    }
}
