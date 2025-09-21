using FluentResults;
using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;
using MediatR;
using System.Collections.Immutable;

namespace GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
public record SelecionarEntradasQuery(int? Quantidade) : IRequest<Result<SelecionarEntradasResult>>;

public record SelecionarEntradasResult(ImmutableList<SelecionarEntradasDTO> Entradas);

public record SelecionarEntradasDTO(
    Guid Id,
    string Ticket,
    DateTime DataHoraEntrada,
    string Placa,
    string Modelo,
    string Cor,
    string CpfHospede,
    string? Observacoes
);