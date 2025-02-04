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
    internal class FamilyMemberRepository : Repository<FamilyMember>, IFamilyMemberRepository
    {
        private readonly ApplicationDbContext _db;

        public FamilyMemberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FamilyMember entity)
        {
            _db.FamilyMembers.Update(entity);
        }
    }
}
