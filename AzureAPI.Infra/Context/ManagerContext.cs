using AzureAPI.Domain.Entity;
using AzureAPI.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AzureAPI.Infra.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        {

        }

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}
