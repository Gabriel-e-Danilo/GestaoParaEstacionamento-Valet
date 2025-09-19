using GestaoParaEstacionamento.Core.Dominio.Compartilhado;
using GestaoParaEstacionamento.Core.Dominio.ModuloVeiculo;
using GestaoParaEstacionamento.Infraestrutura.ORM.Compartilhado;
using GestaoParaEstacionamento.Infraestrutura.ORM.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoParaEstacionamento.Infraestrutura.ORM;

public static class DependencyInjection
{
    public static IServiceCollection AddCamadaInfraestruturaOrm(this IServiceCollection services, IConfiguration configuration) {

        services.AddScoped<IRepositorioVeiculo, RepositorioVeiculoEmORM>();

        services.AddEntityFrameworkConfig(configuration);

        return services;
    }

    private static void AddEntityFrameworkConfig(this IServiceCollection services, IConfiguration configuration) {
        var connectionString = configuration["SQL_CONNECTION_STRING"];

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new Exception("A variável SQL_CONNECTION_STRING não foi fornecida.");

        services.AddDbContext<IUnitOfWork, AppDbContext>(options =>
            options.UseNpgsql(connectionString, (opt) => opt.EnableRetryOnFailure(3)));
    }
}
