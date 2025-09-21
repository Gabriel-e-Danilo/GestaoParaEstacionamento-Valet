using FluentResults;
using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;
using MediatR;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
public record AtualizarObservacaoCommand(
    Guid Id,
    string? Observacao
) : IRequest<Result<AtualizarObservacaoResult>>;

public record AtualizarObservacaoResult(
    string Ticket,
    string? Observacao
);