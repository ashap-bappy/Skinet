using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListWithSpecAsync(ISpecification<T> spec);
        Task<TResult?> GetEntitiesWithSpecAsync<TResult>(ISpecification<T, TResult> spec);
        Task<IReadOnlyList<TResult>> ListWithSpecAsync<TResult>(ISpecification<T, TResult> spec);
        Task<IReadOnlyList<T>> ListAllAsync();
        
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<bool> SaveAllAsync();
        bool Exists(int id);
    }
}
