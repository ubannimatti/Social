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
    internal class SkillRepository : Repository<Skill>, ISkillRepository
    {
        private readonly ApplicationDbContext _db;

        public SkillRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Skill entity)
        {
            _db.Skills.Update(entity);
        }
    }
}
