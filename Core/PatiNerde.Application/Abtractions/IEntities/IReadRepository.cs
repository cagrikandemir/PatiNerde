using Microsoft.EntityFrameworkCore;
using PatiNerde.Domain.Entities;
using System.Linq.Expressions;

namespace PatiNerde.Application.Abtractions.IEntities;

public interface IReadRepository<T , TKey>
    where T : BaseEntity
    where TKey: IQueryable<TKey>
{
    DbSet<T> Table { get; }

    DbContext Context { get; }

    public IQueryable<T> GetAll();

    public Task<T> FindByIdAsync(TKey Id);

    public Task<ICollection<T>> FindListByIdAsync(TKey Id);

    //public IQueryable<T?> Where(Expression<Func<T, bool>> method);

}
