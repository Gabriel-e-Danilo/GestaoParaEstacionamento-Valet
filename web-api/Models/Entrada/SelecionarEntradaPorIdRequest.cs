namespace GestaoParaEstacionamento.WebApi.Models.Entrada;

public record SelecionarEntradaPorIdRequest(Guid Id);

public record SelecionarEntradaPorIdResponse(
    Guid Id,
    string Ticket,
    DateTime DataHoraEntrada,
    string Placa,
    string Modelo,
    string Cor,
    string CpfHospede,
    string? Observacoes
);
