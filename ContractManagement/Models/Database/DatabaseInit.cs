using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContractManagement.Models.Entity;
using ContractManagement.Models.Identity;

namespace ContractManagement.Models.Database
{
    public class DatabaseInit
    {

        public void Initialization(contractDbContext contractDbContext)
        {
            contractDbContext.Database.EnsureCreated();
            if (contractDbContext.Spravci.Count() == 0)
            {
                IList<Spravce> spravci = CreateSpravce();
                foreach (var s in spravci)
                {
                    contractDbContext.Spravci.Add(s);
                }
                contractDbContext.SaveChanges();
            }

           
        }

        public List<Spravce> CreateSpravce()
        {
            List<Spravce> spravci = new List<Spravce>();

            Spravce s1 = new Spravce()
            {
                //ID = 0,
                Jmeno = "Marek",
                Prijmeni = "Novak",
                Email = "mail@mail.com",
                Phone = "937584736",
                RodneCislo = "283746/2937",
                Vek = 25
            };
            Spravce s2 = new Spravce()
            {
                //ID = 1,
                Jmeno = "Petr",
                Prijmeni = "Smejk",
                Email = "hot@hot.com",
                Phone = "614362436",
                RodneCislo = "21689/4321",
                Vek = 35
            };

            Spravce s3 = new Spravce()
            {
                //ID = 2,
                Jmeno = "Jiri",
                Prijmeni = "Mina",
                Email = "meta@meta.com",
                Phone = "464384736",
                RodneCislo = "865846/2342",
                Vek = 21
            }; Spravce s4 = new Spravce()
            {
                //ID = 3,
                Jmeno = "Mirek",
                Prijmeni = "Deml",
                Email = "fix@fix.com",
                Phone = "239561436",
                RodneCislo = "136475/1093",
                Vek = 32
            }; 
            spravci.Add(s1);
            spravci.Add(s2);
            spravci.Add(s3);
            spravci.Add(s4);

            return spravci;
        }

      

        public async Task EnsureRoleCreated(RoleManager<Role> roleManager)
        {
            string[] roles = Enum.GetNames(typeof(Roles));

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(new Role(role));
            }
        }

        public async Task EnsureAdminCreated(UserManager<User> userManager)
        {
            User user = new User
            {
                UserName = "admin",
                Email = "admin@admin.cz",
                EmailConfirmed = true,
                FirstName = "jmeno",
                LastName = "prijmeni"
            };
            string password = "abc";

            User adminInDatabase = await userManager.FindByNameAsync(user.UserName);

            if (adminInDatabase == null)
            {

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result == IdentityResult.Success)
                {
                    string[] roles = Enum.GetNames(typeof(Roles));
                    foreach (var role in roles)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
                else if (result != null && result.Errors != null && result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        Debug.WriteLine($"Error during Role creation for Admin: {error.Code}, {error.Description}");
                    }
                }
            }

        }

        public async Task EnsureManagerCreated(UserManager<User> userManager)
        {
            User user = new User
            {
                UserName = "manager",
                Email = "manager@manager.cz",
                EmailConfirmed = true,
                FirstName = "jmeno :-)",
                LastName = "prijmeni :-)"
            };
            string password = "abc";

            User managerInDatabase = await userManager.FindByNameAsync(user.UserName);

            if (managerInDatabase == null)
            {

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result == IdentityResult.Success)
                {
                    string[] roles = Enum.GetNames(typeof(Roles));
                    foreach (var role in roles)
                    {
                        if (role != Roles.Admin.ToString())
                            await userManager.AddToRoleAsync(user, role);
                    }
                }
                else if (result != null && result.Errors != null && result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        Debug.WriteLine($"Error during Role creation for Manager: {error.Code}, {error.Description}");
                    }
                }
            }

        }

    }
}
