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
    internal class TalukRepository : Repository<Taluk>, ITalukRepository
    {
        private readonly ApplicationDbContext _db;

        public TalukRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Taluk entity)
        {
            _db.Taluks.Update(entity);
        }
    }
}
