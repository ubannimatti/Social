using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Application.Common.Interfaces;
using Social.Application.Common.Utility;
using Social.Domain.Entities;

namespace Social.Infrastructure.Data
{
    public class DbInitializer : IDbInitializer
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }

                var roleexists = _roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult();

                if (!roleexists)
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).Wait();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_DistrictOfficer)).Wait();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_TalukOfficer)).Wait();
                    _userManager.CreateAsync(new ApplicationUser
                    {
                        UserName = "u.bannimatti@gmail.com",
                        Email = "u.bannimatti@gmail.com",
                        Name = "Umesh Bannimatti",
                        NormalizedUserName = "U.BANNIMATTI@GMAIL.COM",
                        NormalizedEmail = "U.BANNIMATTI@GMAIL.COM",
                        PhoneNumber = "9620509503",
                    }, "Admin@123").GetAwaiter().GetResult();

                    ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "u.bannimatti@gmail.com");
                    _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
