using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;

namespace GestaoParaEstacionamento.WebApi.Models.Entrada;

public record CadastrarEntradaRequest(
    VeiculoInfo VeiculoInfo,
    string? Observacoes
);

public record CadastrarEntradaResponse(
    Guid Id,
    Ticket Ticket
);
