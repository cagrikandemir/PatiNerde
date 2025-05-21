using Microsoft.EntityFrameworkCore;
using PatiNerde.Domain.Abtractions.Entities;
using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Persistence.Contexts;

public class PatiNerdeDbContext : DbContext
{
    public PatiNerdeDbContext(DbContextOptions<PatiNerdeDbContext> options) : base(options)
    {

    }

    public DbSet<AppUser> AppUsers => Set<AppUser>();
    public DbSet<AppMapMarker> AppMapMakers => Set<AppMapMarker>();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        DateTime nowDateTime = DateTime.Now;
        foreach (var changedEntity in ChangeTracker.Entries<IBaseEntity>())
        {
            switch (changedEntity.State)
            {
                case EntityState.Added:
                    changedEntity.Entity.CreationTime = nowDateTime;
                    break;

                case EntityState.Modified:
                    Entry(changedEntity.Entity).Property(x => x.CreationTime).IsModified = false;
                    changedEntity.Entity.ModifiyTime = nowDateTime;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}

