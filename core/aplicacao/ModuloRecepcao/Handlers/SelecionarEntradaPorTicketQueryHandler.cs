using FluentResults;
using GestaoParaEstacionamento.Core.Aplicacao.Compartilhado;
using GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Handlers;
public class SelecionarEntradaPorTicketQueryHandler(IRepositorioEntrada repositorioEntrada,
                                                    ILogger<SelecionarEntradaPorTicketQueryHandler> logger)
    : IRequestHandler<SelecionarEntradaPorTicketQuery, Result<SelecionarEntradaPorTicketResult>>
{
    public async Task<Result<SelecionarEntradaPorTicketResult>> Handle(SelecionarEntradaPorTicketQuery query, 
                                                                      CancellationToken cancellationToken) {
        try {
            var e = await repositorioEntrada.SelecionarPorTicketAsync(query.TicketNum);

            if (e is null) return Result.Fail($"Entrada não encontrada para o ticket {query.TicketNum}.");

            var result = new SelecionarEntradaPorTicketResult(
                e.Id,
                e.Ticket.Numero,
                $"T-{e.Ticket.Numero:0000}",
                e.DataHoraEntrada,
                e.Veiculo.Placa.ToString(),
                e.Veiculo.Modelo,
                e.Veiculo.Cor,
                e.Veiculo.CpfHospede.ToString(),
                e.Observacoes
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
