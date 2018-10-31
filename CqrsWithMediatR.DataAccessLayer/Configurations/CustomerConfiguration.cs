using System;
using System.Collections.Generic;
using System.Text;
using CqrsWithMediatR.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CqrsWithMediatR.DataAccessLayer.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);
            builder.Property(c => c.CustomerName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.CompanyName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Address).HasMaxLength(200).IsRequired();
            builder.Property(c => c.City).HasMaxLength(20).IsRequired();
            builder.Property(c => c.PostalCode).HasMaxLength(10).IsRequired();
            builder.Property(c => c.Country).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Phone).HasMaxLength(20).IsRequired();
        }
    }
}
