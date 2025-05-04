using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PatiNerde.Application.Abtractions.IEntities;
using PatiNerde.Domain.Entities;
using PatiNerde.Persistence.Contexts;

namespace PatiNerde.Persistence.Entities;

public class WriteRepository<T, TKey> : IWriteRepository<T, TKey>
    where T : BaseEntity
    where TKey : IQueryable<TKey>
{
    private readonly PatiNerdeDbContext _context;

    public WriteRepository(PatiNerdeDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public DbContext Context => _context;

    public async Task<T?> AddAsync(T model)
    {
        EntityEntry entity = await Table.AddAsync(model);
        if (entity.State == await Task.FromResult(EntityState.Added))
            return model;

        return null;
    }

    public async Task<ICollection<T>> AddMultiAsync(ICollection<T> models)
    {
        if (models.Count <= 20)
        {
            foreach (T item in models)
            {
                EntityEntry entity = await Table.AddAsync(item);
                if (entity.State != await Task.FromResult(EntityState.Added))
                    models.Remove(item);
            }
            return models;
        }
        else
            throw new InvalidOperationException("You can't add more than 20 items at once");
    }

    public async Task<bool> RemoveAsync(T model)
    {
        EntityEntry entity = Table.Remove(model);
        return (entity.State == await Task.FromResult(EntityState.Deleted));
    }

    public async Task<bool> RemoveByIdAsync(TKey id)
    {
        T? model = await Table.FindAsync(id);
        if (model == null)
            return false;

        return await RemoveAsync(model);
    }

    public async Task<ICollection<T>> RemoveMultiAsync(ICollection<T> models)
    {
        if (models.Count > 20)
            throw new InvalidOperationException("You can't add more than 20 items at once");

        foreach (T item in models)
        {
            if (!await RemoveAsync(item))
                models.Remove(item);
        }
        return models;
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<EntityEntry> UpdateAsync(T model)
    {
        EntityEntry entity = Table.Update(model);
        return await Task.FromResult(entity);
    }

    public async Task<bool> UpdateByIdAsync(TKey id)
    {
        throw new Exception("Not implemented yet");
        //T? model= await Table.FindAsync(id);
        //if (model != null)
        //    return await UpdateAsync(model);

    }

    public async Task<ICollection<T>> UpdateMultiAsync(ICollection<T> models)
    {
        if (models.Count >= 20)
            throw new InvalidOperationException("You can't update more than 20 items at once");
        foreach (T item in models)
        {
            if ((await UpdateAsync(item)).State != EntityState.Modified)
                models.Remove(item);
        }
        return models;
    }
}
