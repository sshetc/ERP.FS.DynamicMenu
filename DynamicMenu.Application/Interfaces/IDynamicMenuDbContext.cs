using Microsoft.EntityFrameworkCore;
using DynamicMenu.Domain;

namespace DynamicMenu.Application.Interfaces
{
    public interface IDynamicMenuDbContext
    {
        DbSet<Menu> Menu { get; set; }
        DbSet<MenuItem> MenuItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken); 
    }
}
