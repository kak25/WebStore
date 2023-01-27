using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.DataAccess.Data;
using Store.DataAccess.Repository.IRepository;
using Store.Models;
using Store.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.DbInitalizer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext db)
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
            }
            catch (Exception ex)
            {

            }

            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Individual)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@admin.is",
                    Email = "admin@admin.is",
                    Name = "Kári Kjærnested",
                    PhoneNumber = "8880000",
                    Address = "Svarthamrar 16",
                    PostalCode = "112",
                    City = "Reykjavík"
                }, "").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@admin.is");

                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();


            }
            return;
        }
    }
}
