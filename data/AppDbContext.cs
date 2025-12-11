using Crud.model;
using Microsoft.EntityFrameworkCore;

namespace Crud.data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options)
    :base(options) {}

   public DbSet<Profile> Profiles => Set<Profile>();
}