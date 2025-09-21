using FluentResults;
using MediatR;
using System.Collections.Immutable;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
public record SelecionarEntradaPorTicketQuery(int TicketNum)
    : IRequest<Result<SelecionarEntradaPorTicketResult>>;

public record SelecionarEntradaPorTicketResult(
    Guid Id,
    int TicketNum,
    string TicketCodigo,
    DateTime DataHoraEntrada,
    string Placa,
    string Modelo,
    string Cor,
    string CpfHospede,
    string? Observacoes
);