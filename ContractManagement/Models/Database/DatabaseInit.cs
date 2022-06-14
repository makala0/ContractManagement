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
            if (contractDbContext.Consultants.Count() == 0)
            {
                IList<Consultant> spravci = CreateConsultant();
                foreach (var s in spravci)
                {
                    contractDbContext.Consultants.Add(s);
                }
                contractDbContext.SaveChanges();
            }

            if (contractDbContext.Institutions.Count() == 0)
            {
                IList<Institution> ins = CreateInstitution();
                foreach (var i in ins)
                {
                    contractDbContext.Institutions.Add(i);
                }
                contractDbContext.SaveChanges();
            }

            if (contractDbContext.Contracts.Count() == 0)
            {
                IList<Contract> con = CreateContract();
                foreach (var c in con)
                {
                    contractDbContext.Contracts.Add(c);
                }
                contractDbContext.SaveChanges();
            }

            
        }

            public List<Consultant> CreateConsultant()
        {
            List<Consultant> spravci = new List<Consultant>();

            Consultant s1 = new Consultant()
            {
                //ID = 1,
                FirstName = "Marek",
                LastName = "Novak",
                Email = "mail@mail.com",
                Phone = "937584736",
                BirthNumber = "283746/2937",
                Age = 25
            };
            Consultant s2 = new Consultant()
            {
                //ID = 2,
                FirstName = "Petr",
                LastName = "Smejk",
                Email = "hot@hot.com",
                Phone = "614362436",
                BirthNumber = "216896/4381",
                Age = 35
            };

            Consultant s3 = new Consultant()
            {
                //ID = 3,
                FirstName = "Jiri",
                LastName = "Mina",
                Email = "meta@meta.com",
                Phone = "464384736",
                BirthNumber = "865846/2342",
                Age = 21
            }; Consultant s4 = new Consultant()
            {
                //ID = 4,
                FirstName = "Mirek",
                LastName = "Deml",
                Email = "fix@fix.com",
                Phone = "239561436",
                BirthNumber = "136475/1093",
                Age = 32
            }; 
            spravci.Add(s1);
            spravci.Add(s2);
            spravci.Add(s3);
            spravci.Add(s4);

            return spravci;
        }

        public List<Institution> CreateInstitution()
        {
            List<Institution> ins = new List<Institution>();

            Institution i1 = new Institution()
            {
                //ID = 1,
                Name = "CSOB",
                ConsultantID = 1
                
            };

            Institution i2 = new Institution()
            {
                //ID = 2,
                Name = "AEGON",
                ConsultantID = 3

            };

            Institution i3 = new Institution()
            {
                //ID = 3,
                Name = "AXA",
                ConsultantID = 2

            };

            Institution i4 = new Institution()
            {
                //ID = 4,
                Name = "Kooperativa",
                ConsultantID = 4

            };

            ins.Add(i1);
            ins.Add(i2);
            ins.Add(i3);
            ins.Add(i4);

            return ins;
        }

        public List<Contract> CreateContract()
        {
            List<Contract> con = new List<Contract>();

            Contract c1 = new Contract()
            {
                //ID = 1,
                RegistrationNumber = 1020,
                InstitutionID = 3,
                ClosedDate = DateTime.Now,
                ValidityDate = DateTime.Now,
                EndDate = DateTime.Now,
                UserId = 4
            };

            Contract c2 = new Contract()
            {
                //ID = 2,
                RegistrationNumber = 1021,
                InstitutionID = 2,
                ClosedDate = DateTime.Now,
                ValidityDate = DateTime.Now,
                EndDate = DateTime.Now,
                UserId = 3
            };

            Contract c3 = new Contract()
            {
                //ID = 3,
                RegistrationNumber = 1022,
                InstitutionID = 4,
                ClosedDate = DateTime.Now,
                ValidityDate = DateTime.Now,
                EndDate = DateTime.Now,
                UserId = 2
            };

            Contract c4 = new Contract()
            {
                //ID = 4,
                RegistrationNumber = 2023,
                InstitutionID = 1,
                ClosedDate = DateTime.Now,
                ValidityDate = DateTime.Now,
                EndDate = DateTime.Now,
                UserId = 4
            };

            Contract c5 = new Contract()
            {
                //ID = 5,
                RegistrationNumber = 2024,
                InstitutionID = 3,
                ClosedDate = DateTime.Now,
                ValidityDate = DateTime.Now,
                EndDate = DateTime.Now,
                UserId = 3
            };

            con.Add(c1);
            con.Add(c2);
            con.Add(c3);
            con.Add(c4);
            con.Add(c5);



            return con;
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
                LastName = "prijmeni",
                BirthNumber = "------/----",
                Age = 99,
                Phone = "000000000"
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

       

        public async Task EnsureCustomer1Created(UserManager<User> userManager)
        {
            User user = new User
            {
                UserName = "customer",
                Email = "customer@customer.cz",
                EmailConfirmed = true,
                FirstName = "jmeno",
                LastName = "prijmeni",
                BirthNumber = "2746389/1234",
                Age = 25,
                Phone = "235738467"
            };
            string password = "abc";

            User customerInDatabase = await userManager.FindByNameAsync(user.UserName);

            if (customerInDatabase == null)
            {

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result == IdentityResult.Success)
                {
                    string[] roles = Enum.GetNames(typeof(Roles));
                    foreach (var role in roles)
                    {
                        if (role == Roles.Customer.ToString())
                            await userManager.AddToRoleAsync(user, role);
                    }
                }
                else if (result != null && result.Errors != null && result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        Debug.WriteLine($"Error during Role creation for Customer: {error.Code}, {error.Description}");
                    }
                }
            }

        }

        public async Task EnsureCustomer2Created(UserManager<User> userManager)
        {
            User user = new User
            {
                UserName = "customer2",
                Email = "customer2@customer2.cz",
                EmailConfirmed = true,
                FirstName = "Karel",
                LastName = "Maly",
                BirthNumber = "226342/3234",
                Age = 21,
                Phone = "849367485"
            };
            string password = "abc";

            User customerInDatabase = await userManager.FindByNameAsync(user.UserName);

            if (customerInDatabase == null)
            {

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result == IdentityResult.Success)
                {
                    string[] roles = Enum.GetNames(typeof(Roles));
                    foreach (var role in roles)
                    {
                        if (role == Roles.Customer.ToString())
                            await userManager.AddToRoleAsync(user, role);
                    }
                }
                else if (result != null && result.Errors != null && result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        Debug.WriteLine($"Error during Role creation for Customer: {error.Code}, {error.Description}");
                    }
                }
            }

        }

        public async Task EnsureCustomer3Created(UserManager<User> userManager)
        {
            User user = new User
            {
                UserName = "customer3",
                Email = "customer3@customer3.cz",
                EmailConfirmed = true,
                FirstName = "Karolina",
                LastName = "Zdejsi",
                BirthNumber = "938465/9375",
                Age = 27,
                Phone = "048576847"
            };
            string password = "abc";

            User customerInDatabase = await userManager.FindByNameAsync(user.UserName);

            if (customerInDatabase == null)
            {

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result == IdentityResult.Success)
                {
                    string[] roles = Enum.GetNames(typeof(Roles));
                    foreach (var role in roles)
                    {
                        if (role == Roles.Customer.ToString())
                            await userManager.AddToRoleAsync(user, role);
                    }
                }
                else if (result != null && result.Errors != null && result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        Debug.WriteLine($"Error during Role creation for Customer: {error.Code}, {error.Description}");
                    }
                }
            }

        }

    }
}
