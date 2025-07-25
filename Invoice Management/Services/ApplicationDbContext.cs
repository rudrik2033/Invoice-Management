using Invoice_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Management.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; } = null!;

    }
}
