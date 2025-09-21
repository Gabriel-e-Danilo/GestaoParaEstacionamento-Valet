using FluentResults;
using GestaoParaEstacionamento.Core.Aplicacao.Compartilhado;
using GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Handlers;
public class SelecionarEntradaPorIdQueryHandler(IRepositorioEntrada repositorioContato,
                                                ILogger<SelecionarEntradasQueryHandler> logger)
    : IRequestHandler<SelecionarEntradaPorIdQuery, Result<SelecionarEntradaPorIdResult>>
{
    public async Task<Result<SelecionarEntradaPorIdResult>> Handle(SelecionarEntradaPorIdQuery query, 
                                                                   CancellationToken cancellationToken) {
		try {
            var registro = await repositorioContato.SelecionarRegistroPorIdAsync(query.Id);

            if (registro is null) return Result.Fail(ResultadosErro.RegistroNaoEncontradoErro(query.Id));

            var result = new SelecionarEntradaPorIdResult(
                registro.Id,
                $"T-{registro.Ticket.Numero:D4}",
                registro.DataHoraEntrada,
                registro.Veiculo.Placa.ToString(),
                registro.Veiculo.Modelo.ToString(),
                registro.Veiculo.Cor.ToString(),
                registro.Veiculo.CpfHospede.Numeros.ToString(),
                registro.Observacoes
            );

            return Result.Ok(result);

        } catch (Exception ex) {
            logger.LogError(
                ex,
                "Ocorreu um erro durante a seleção de {@Registro}",
                query);

            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
        }
    }
}
