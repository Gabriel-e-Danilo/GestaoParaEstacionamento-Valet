using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;

namespace GestaoParaEstacionamento.WebApi.Models.Entrada;

public record CadastrarEntradaRequest(
    string Placa,
    string Modelo,
    string Cor,
    string CpfHospede,
    string? Observacoes
);

public record CadastrarEntradaResponse(
    Guid Id
);
