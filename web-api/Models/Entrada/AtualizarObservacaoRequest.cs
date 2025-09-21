using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;

namespace GestaoParaEstacionamento.WebApi.Models.Entrada;

public record AtualizarObservacaoRequest(
    string? Observacao
);
