using CqrsWithMediatR.DataAccessLayer.Extensions;
using CqrsWithMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace CqrsWithMediatR.DataAccessLayer
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
