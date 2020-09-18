using CqrsWithMediatR.Domain.Entities;
using CqrsWithMediatR.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CqrsWithMediatR.Infrastructure.Data
{
    public class CqrsWithMediatRDbContext : DbContext
    {
        public CqrsWithMediatRDbContext(DbContextOptions<CqrsWithMediatRDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurations();

        }
    }
}
