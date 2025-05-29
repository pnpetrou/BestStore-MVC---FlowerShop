using Microsoft.EntityFrameworkCore;
using BestStoreMVC.Models;

namespace BestStoreMVC.Services
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Flower> Flowers { get; set; }
    }
}
