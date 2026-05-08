using Tasktracker.Domain.Interfaces;

namespace Tasktracker.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity?> GetLatestAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
