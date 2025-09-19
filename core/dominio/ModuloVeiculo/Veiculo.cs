using GestaoParaEstacionamento.Core.Dominio.Compartilhado;

namespace GestaoParaEstacionamento.Core.Dominio.ModuloVeiculo;
public class Veiculo : EntidadeBase<Veiculo>
{
    public string Placa { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public string CpfHospede { get; set; } = string.Empty;

    public bool Status { get; set; } = true;

    public Veiculo() { }

    public Veiculo(string placa, string modelo, string cor, string cpfHospede) {
        Id = Guid.NewGuid();
        Placa = placa;
        Modelo = modelo;
        Cor = cor;
        CpfHospede = cpfHospede;
        Status = true;
    }

    public override void AtualizarRegistro(Veiculo registroEditado) {
        Placa = registroEditado.Placa;
        Modelo = registroEditado.Modelo;
        Cor = registroEditado.Cor;
        CpfHospede = registroEditado.CpfHospede;
        Status = registroEditado.Status;
    }

    public void Arquivar() => Status = false;
    public void Reativar() => Status = true;
}
