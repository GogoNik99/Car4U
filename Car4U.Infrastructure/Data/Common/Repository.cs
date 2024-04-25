using Car4U.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Car4U.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext _context;

        public Repository(Car4UDbContext context)
        {
            _context = context;
        }

        private DbSet<T> DbSet<T>() where T : class
            => _context.Set<T>();


        public async Task AddAsync<T>(T entity) where T : class
            => await DbSet<T>().AddAsync(entity);

        public IQueryable<T> All<T>() where T : class
            => DbSet<T>();

        public IQueryable<T> AllReadOnly<T>() where T : class
            => DbSet<T>().AsNoTracking();


        public async Task DeleteAsync<T>(object id) where T : class
        {
            T? entity = await GetByIdAsync<T>(id);

            if (entity != null)
            {
                DbSet<T>().Remove(entity);
            }
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
            => await DbSet<T>().FindAsync(id);

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
