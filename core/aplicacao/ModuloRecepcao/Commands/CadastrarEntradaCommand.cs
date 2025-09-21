using FluentResults;
using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;
using MediatR;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
public record CadastrarEntradaCommand(
    VeiculoInfo VeiculoInfo,
    string? Observacoes
) : IRequest<Result<CadastrarEntradaResult>>;

public record CadastrarEntradaResult(Guid Id);