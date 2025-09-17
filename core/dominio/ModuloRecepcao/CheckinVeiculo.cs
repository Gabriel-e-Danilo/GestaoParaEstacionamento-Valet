using GestaoParaEstacionamento.Core.Dominio.Compartilhado;

namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
public class CheckinVeiculo : EntidadeBase<CheckinVeiculo>
{
    public string Placa { get;  set; } = string.Empty;
    public string Modelo { get;  set; } = string.Empty;
    public string Cor { get;  set; } = string.Empty;

    public string CpfHospede { get;  set; } = string.Empty;

    public long Ticket { get; set; } //gerador automatico pela API
    public DateTime DataEntrada { get; private set; } = DateTime.UtcNow;
    public string Observacoes { get; set; } = string.Empty;

    public CheckinVeiculo() { }

    public CheckinVeiculo(string placa, string modelo, string cor, string cpfHospede, string? observacoes) {
        Id = Guid.NewGuid();
        Placa = placa;
        Modelo = modelo;
        Cor = cor;
        CpfHospede = cpfHospede;
        Observacoes = observacoes ?? string.Empty;
    }

    public override void AtualizarRegistro(CheckinVeiculo registroEditado) {
        Placa = registroEditado.Placa;
        Modelo = registroEditado.Modelo;
        Cor = registroEditado.Cor;
        CpfHospede = registroEditado.CpfHospede;
        Observacoes = registroEditado.Observacoes;
    }
}
