using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PatiNerde.Application.Abtractions.IEntities;

public interface IWriteRepository<T, TKey>
    where T : class
    where TKey : IQueryable<TKey>
{
    DbSet<T> Table { get; }
    DbContext Context { get; }

    Task<T?> AddAsync(T model);

    Task<ICollection<T>> AddMultiAsync(ICollection<T> models);

    Task<bool> RemoveAsync(T model);

    Task<bool> RemoveByIdAsync(TKey id);

    Task<ICollection<T>> RemoveMultiAsync(ICollection<T> models);

    Task<EntityEntry> UpdateAsync(T model);

    Task<bool> UpdateByIdAsync(TKey id);

    Task<ICollection<T>> UpdateMultiAsync(ICollection<T> models);

    Task<int> SaveAsync(CancellationToken cancellationToken = default!);
}
