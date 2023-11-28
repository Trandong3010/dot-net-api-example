using API.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        int Save();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save() {
            return _context.SaveChanges(); 
        }

        public DbSet<T> Set<T>() where T : class
        {
            return _context.Set<T>();
        }
    }
}
