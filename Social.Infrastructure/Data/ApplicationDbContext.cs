using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Social.Domain.Entities;

namespace Social.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Taluk> Taluks { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Taluk>().HasData(
                GetTaluks()
            );

            modelBuilder.Entity<Skill>().HasData(
                GetSkills()
            );


            modelBuilder.Entity<EmployeeSkill>()
           .HasKey(es => new { es.EmployeeId, es.SkillId });

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(es => es.Employee)
                .WithMany(e => e.EmployeeSkills)
                .HasForeignKey(es => es.EmployeeId);
        }

        private IEnumerable<Taluk> GetTaluks()
        {
            return new List<Taluk>()
            {
                new Taluk
                {
                    TalukId = 1,
                    TalukName = "Mandya"
                },
                new Taluk
                {
                    TalukId = 2,
                    TalukName = "Krishnarajpet"
                },
                new Taluk
                {
                    TalukId = 3,
                    TalukName = "Maddur"
                },
                new Taluk
                {
                    TalukId = 4,
                    TalukName = "Malavalli"
                },
                new Taluk
                {
                    TalukId = 5,
                    TalukName = "Nagamangala"
                },
                new Taluk
                {
                    TalukId = 6,
                    TalukName = "Pandavapura"
                },
                new Taluk
                {
                    TalukId = 7,
                    TalukName = "Shrirangapanttana"
                }
            };
        }
        private IEnumerable<Skill> GetSkills()
        {
            return new List<Skill>()
            {
                new Skill { SkillId = 1, SkillName = "Tailoring" },
                new Skill { SkillId = 2, SkillName = "Driving" },
                new Skill { SkillId = 3, SkillName = "Computer Excel, Tally etc." },
                new Skill { SkillId = 4, SkillName = "Hotel Management" },
                new Skill { SkillId = 5, SkillName = "Dairy Farming" },
                new Skill { SkillId = 6, SkillName = "Beautician" },
                new Skill { SkillId = 7, SkillName = "Enterprises" },
                new Skill { SkillId = 8, SkillName = "Community service" }
            };
        }
    }
}
