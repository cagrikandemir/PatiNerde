using Microsoft.EntityFrameworkCore;
using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Persistence.Contexts;

public class PatiNerdeDbContext : DbContext
{
    public PatiNerdeDbContext(DbContextOptions<PatiNerdeDbContext> options) : base(options)
    {

    }

    public DbSet<AppUser> AppUsers => Set<AppUser>();
}

