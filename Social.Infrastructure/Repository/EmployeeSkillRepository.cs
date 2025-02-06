using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Application.Common.Interfaces;
using Social.Domain.Entities;
using Social.Infrastructure.Data;

namespace Social.Infrastructure.Repository
{
    internal class EmployeeSkillRepository : Repository<EmployeeSkill>, IEmployeeSkillRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeSkillRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EmployeeSkill entity)
        {
            _db.EmployeeSkills.Update(entity);
        }
    }
}
