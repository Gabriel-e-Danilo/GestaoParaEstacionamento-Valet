using FluentResults;
using GestaoParaEstacionamento.Core.Aplicacao.Compartilhado;
using GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Handlers;
public class SelecionarEntradasQueryHandler(IRepositorioEntrada repositorioEntrada,
                                            ILogger<SelecionarEntradasQueryHandler> logger)
    : IRequestHandler<SelecionarEntradasQuery, Result<SelecionarEntradasResult>>
{
    public async Task<Result<SelecionarEntradasResult>> Handle(SelecionarEntradasQuery query, 
                                                              CancellationToken cancellationToken) {
		try {
            var registros = query.Quantidade.HasValue 
                ? await repositorioEntrada.SelecionarRegistrosAsync(query.Quantidade.Value) 
                : await repositorioEntrada.SelecionarRegistrosAsync();

            var itens = registros.Select(e => new SelecionarEntradasDTO(
                    e.Id,
                    $"T-{e.Ticket.Numero:D4}",
                    e.DataHoraEntrada,
                    e.Veiculo.Placa.ToString(),
                    e.Veiculo.Modelo.ToString(),
                    e.Veiculo.Cor.ToString(),
                    e.Veiculo.CpfHospede.Numeros.ToString(),
                    e.Observacoes
                )).ToImmutableList();

            var result = new SelecionarEntradasResult(itens);

            return Result.Ok(result);

        } catch (Exception ex) {
            logger.LogError(ex, "Ocorreu um erro durante a seleção de {@Registros}.", query);

            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
        }
    }
}
