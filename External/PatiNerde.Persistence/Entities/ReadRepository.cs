using Microsoft.EntityFrameworkCore;
using PatiNerde.Application.Abtractions.IEntities;
using PatiNerde.Domain.Entities;
using PatiNerde.Persistence.Contexts;

namespace PatiNerde.Persistence.Entities;

public class ReadRepository<T, TKey> : IReadRepository<T, TKey>
    where T : BaseEntity
    where TKey : IQueryable<TKey>
{
    private readonly PatiNerdeDbContext _context;
    public ReadRepository(PatiNerdeDbContext context)
    {
        _context = context;
    }
    public DbSet<T> Table => _context.Set<T>();

    public DbContext Context => _context;

    public async Task<T?> FindByIdAsync(TKey Id)
    {
        var entity = await Table.FindAsync(Id);
        if (entity == null)
            return null;
        else
            return entity;
    }

    public async Task<ICollection<T>> FindListByIdAsync(TKey Id)
    {
        ICollection<T> list = new List<T>();

        T? entity = await FindByIdAsync(Id);

        if (entity !=null)
        {
            list.Add(entity);
        }
        return await Task.FromResult(list);
    }

    public IQueryable<T> GetAll()
    {
        return Table.AsQueryable();
    }

    //public IQueryable<T?> Where(Expression<Func<T, bool>> method)
    //{
    //    throw new NotImplementedException();
    //}
}
