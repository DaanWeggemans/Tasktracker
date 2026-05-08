using Microsoft.EntityFrameworkCore;
using Tasktracker.Application.Interfaces.Repositories;
using Tasktracker.Domain.Interfaces;
using Tasktracker.Infrastructure.Persistence;

namespace Tasktracker.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly ApplicationDBContext Context;
        private readonly DbSet<TEntity> Set;

        public Repository(ApplicationDBContext context)
        {
            Context = context;
            Set = Context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await Set.ToListAsync();

        public async Task<TEntity?> GetByIdAsync(Guid id)
            => await Set.FindAsync(id);

        public async Task<TEntity?> GetLatestAsync()
            => await Set.OrderByDescending(e => e.CreatedAt)
                .FirstOrDefaultAsync();

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            Set.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Set.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Set.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
