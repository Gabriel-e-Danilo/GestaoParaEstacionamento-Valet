using Microsoft.EntityFrameworkCore;

namespace GestaoParaEstacionamento.Infraestrutura.ORM.Compartilhado;
public static class AppDbContextFactory
{
    public static AppDbContext CriarDbContext(string connectionString) {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        var dbContext = new AppDbContext(options);

        return dbContext;
    }
}