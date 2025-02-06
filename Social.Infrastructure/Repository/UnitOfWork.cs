using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Application.Common.Interfaces;
using Social.Infrastructure.Data;

namespace Social.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IEmployeeRepository Employee { get; private set; }
        public IEmployeeSkillRepository EmployeeSkill { get; private set; }

        public ITalukRepository Taluk { get; private set; }

        public IFamilyMemberRepository FamilyMember { get; private set; }

        public ISkillRepository Skill { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Employee = new EmployeeRepository(_db);
            EmployeeSkill = new EmployeeSkillRepository(_db);
            Skill = new SkillRepository(_db);
            FamilyMember = new FamilyMemberRepository(_db);
            Taluk = new TalukRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
