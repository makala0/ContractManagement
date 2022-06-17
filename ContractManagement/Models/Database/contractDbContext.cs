using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContractManagement.Models.Database;
using ContractManagement.Models.Entity;
using ContractManagement.Models.Identity;
using ContractManagement.Models.Database.Configurations;

namespace ContractManagement.Models.Database
{
    public class contractDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Institution> Institutions { get; set; }

        public contractDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Contract>(new ContractConfiguration());

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().Replace("AspNet", String.Empty));
            }
        }
    }
}
