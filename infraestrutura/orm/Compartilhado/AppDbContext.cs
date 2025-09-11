using GestaoParaEstacionamento.Core.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace GestaoParaEstacionamento.Infraestrutura.Orm.Compartilhado;
public class AppDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    // public DbSet<Tralala> Tralala { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        var assembly = typeof(AppDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(modelBuilder);
    }
    public async Task CommitAsync() {
        await SaveChangesAsync();
    }

    public async Task RollbackAsync() {

        foreach (var entry in ChangeTracker.Entries()) {

            switch (entry.State) {

                case EntityState.Added:
                    entry.State = EntityState.Unchanged;
                    break;

                case EntityState.Modified:
                    entry.State = EntityState.Unchanged;
                    break;

                case EntityState.Deleted:
                    entry.State = EntityState.Unchanged;
                    break;
            }
        }

        await Task.CompletedTask;
    }
}
