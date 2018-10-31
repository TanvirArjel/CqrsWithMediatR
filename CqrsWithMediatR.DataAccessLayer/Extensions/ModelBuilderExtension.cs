using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace CqrsWithMediatR.DataAccessLayer.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces()
                .Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
