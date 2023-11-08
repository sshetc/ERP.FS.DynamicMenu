using DynamicMenu.Application.Interfaces;
using DynamicMenu.Domain;
using DynamicMenu.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DynamicMenu.Persistence
{
    public class DynamicMenuDbContext : DbContext, IDynamicMenuDbContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DynamicMenuDbContext(DbContextOptions<DynamicMenuDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new MenuItemConfiguration());
            modelBuilder.UseSerialColumns();
        }
    }
}
