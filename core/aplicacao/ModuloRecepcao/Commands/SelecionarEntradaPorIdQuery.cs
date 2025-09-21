using MediatR;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
public record SelecionarEntradaPorIdQuery(Guid Id) : IRequest<FluentResults.Result<SelecionarEntradaPorIdResult>>;

public record SelecionarEntradaPorIdResult(
    Guid Id,
    string Ticket,
    DateTime DataHoraEntrada,
    string Placa,
    string Modelo,
    string Cor,
    string CpfHospede,
    string? Observacoes
);