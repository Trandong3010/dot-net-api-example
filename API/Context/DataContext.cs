using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
