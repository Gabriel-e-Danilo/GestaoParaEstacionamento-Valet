using GestaoParaEstacionamento.Core.Aplicacao.ModuloRecepcao.Commands;
using System.Collections.Immutable;

namespace GestaoParaEstacionamento.WebApi.Models.Entrada;

public record SelecionarEntradasRequest(
    int? Quantidade
);

public record SelecionarEntradasResponse(
    int Quantidade,
    ImmutableList<SelecionarEntradasDTO> Entradas
);
