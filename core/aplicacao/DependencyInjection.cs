using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

public static class DependencyInjection
{
    public static IServiceCollection AddCamadaAplicacao(this IServiceCollection services, ILoggingBuilder logging, IConfiguration configuration) {
        services.AddSerilogConfig(logging, configuration);

        return services;
    }

    private static void AddSerilogConfig(this IServiceCollection services, ILoggingBuilder logging, IConfiguration configuration) {
        string? licenseKey = configuration["NEWRELIC_LICENSE_KEY"];

        if (string.IsNullOrEmpty(licenseKey)) throw new Exception("A variável NEWRELIC_LICENSE_KEY não foi fornecida.");

        string caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        string caminhoArquivoLogs = Path.Combine(caminhoAppData, "GestaoParaEstacionamento-Valet", "erro.log");
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(caminhoArquivoLogs, LogEventLevel.Error)
            .WriteTo.NewRelicLogs(
                endpointUrl: "https://log-api.newrelic.com/log/v1",
                applicationName: "gestao-para-estacionamento-app",
                licenseKey: licenseKey
            )
            .CreateLogger();

        logging.ClearProviders();

        services.AddSerilog();
    }
}
