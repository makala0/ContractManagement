using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContractManagement.Models.Entity;

namespace ContractManagement.Models.Database.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.Property(nameof(Contract.DateTimeCreated)).HasDefaultValueSql("GETDATE()");
        }
    }
}
