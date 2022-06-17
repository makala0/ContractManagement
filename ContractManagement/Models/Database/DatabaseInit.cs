using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContractManagement.Models.Entity;
using ContractManagement.Models.Identity;
using System.Globalization;

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
                ConsultantID = 1

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
                ConsultantID = 2

            };

            Institution i5 = new Institution()
            {
                //ID = 5,
                Name = "UNIQA",
                ConsultantID = 3

            };

            Institution i6 = new Institution()
            {
                //ID = 6,
                Name = "Alianz",
                ConsultantID = 3

            };

            Institution i7 = new Institution()
            {
                //ID = 7,
                Name = "Generali",
                ConsultantID = 4

            };

            Institution i8 = new Institution()
            {
                //ID = 8,
                Name = "Aviva",
                ConsultantID = 4

            };
            ins.Add(i1);
            ins.Add(i2);
            ins.Add(i3);
            ins.Add(i4);
            ins.Add(i5);
            ins.Add(i6);
            ins.Add(i7);
            ins.Add(i8);

            return ins;
        }

        public List<Contract> CreateContract()
        {
            List<Contract> con = new List<Contract>();

            Contract c1 = new Contract()
            {
                //ID = 1,
                RegistrationNumber = 1021,
                InstitutionID = 1,
                ClosedDate = DateTime.ParseExact("2013-04-11", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                ValidityDate = DateTime.ParseExact("2013-01-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2014-04-23", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                UserId = 2
            };

            Contract c2 = new Contract()
            {
                //ID = 2,
                RegistrationNumber = 1022,
                InstitutionID = 2,
                ClosedDate = DateTime.ParseExact("2007-03-22", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                ValidityDate = DateTime.ParseExact("2007-03-20", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2011-03-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                UserId = 2
            };

            Contract c3 = new Contract()
            {
                //ID = 3,
                RegistrationNumber = 1023,
                InstitutionID = 3,
                ClosedDate = DateTime.ParseExact("2011-05-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                ValidityDate = DateTime.ParseExact("2011-03-07", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2015-09-09", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                UserId = 2
            };

            Contract c4 = new Contract()
            {
                //ID = 4,
                RegistrationNumber = 1024,
                InstitutionID = 4,
                ClosedDate = DateTime.ParseExact("2017-02-11", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                ValidityDate = DateTime.ParseExact("2017-02-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2022-12-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                UserId = 3
            };

            Contract c5 = new Contract()
            {
                //ID = 5,
                RegistrationNumber = 1025,
                InstitutionID = 5,
                ClosedDate = DateTime.ParseExact("2001-04-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                ValidityDate = DateTime.ParseExact("2001-03-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2008-07-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                UserId = 3
            };

            Contract c6 = new Contract()
            {
                //ID = 6,
                RegistrationNumber = 1026,
                InstitutionID = 6,
                ClosedDate = DateTime.ParseExact("1996-06-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                ValidityDate = DateTime.ParseExact("1996-04-05", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2008-08-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                UserId = 3
            };

            Contract c7 = new Contract()
            {
                //ID = 7,
                RegistrationNumber = 1027,
                InstitutionID = 7,
                ClosedDate = DateTime.ParseExact("1999-05-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                ValidityDate = DateTime.ParseExact("2001-08-26", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2012-07-11", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                UserId = 4
            };

            Contract c8 = new Contract()
            {
                //ID = 8,
                RegistrationNumber = 1028,
                InstitutionID = 8,
                ClosedDate = DateTime.ParseExact("2022-04-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                ValidityDate = DateTime.ParseExact("2022-04-02", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2025-07-27", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                UserId = 4
            };

            Contract c9 = new Contract()
            { 
                //ID = 9,
                RegistrationNumber = 1029,
                InstitutionID = 2,
                ClosedDate = DateTime.ParseExact("2000-03-09", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                ValidityDate = DateTime.ParseExact("2000-06-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2011-02-16", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                UserId = 4
            };

            Contract c10 = new Contract()
            {
                //ID = 10,
                RegistrationNumber = 1031,
                InstitutionID = 4,
                ClosedDate = DateTime.ParseExact("2004-04-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                ValidityDate = DateTime.ParseExact("2004-04-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2008-01-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                UserId = 2
            };

            Contract c11 = new Contract()
            {
                //ID = 11,
                RegistrationNumber = 2032,
                InstitutionID = 5,
                ClosedDate = DateTime.ParseExact("2017-11-07", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                ValidityDate = DateTime.ParseExact("2017-11-08", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2023-07-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                UserId = 3
            };

            con.Add(c1);
            con.Add(c2);
            con.Add(c3);
            con.Add(c4);
            con.Add(c5);
            con.Add(c6);
            con.Add(c7);
            con.Add(c8);
            con.Add(c9);
            con.Add(c10);
            con.Add(c11);

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
                FirstName = "Marcel",
                LastName = "Novotny",
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
