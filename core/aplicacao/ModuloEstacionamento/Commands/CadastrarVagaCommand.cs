using FluentResults;
using MediatR;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloEstacionamento.Commands;

// quando cadastramos
public record CadastrarVagaCommand(
    int Identificador,
    string Zona
) : IRequest<Result<CadastrarVagaResult>>;

// quando retornamos
public record CadastrarVagaResult(Guid Id);