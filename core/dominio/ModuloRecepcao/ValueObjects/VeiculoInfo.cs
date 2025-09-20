namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;

public sealed record class VeiculoInfo
{
    public Placa Placa { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public string Cor { get; set; } = null!;
    public CpfHospede CpfHospede { get; set; } = null!;

    private VeiculoInfo() { }

    private VeiculoInfo(Placa placa, string modelo, string cor, CpfHospede cpfHospede) {
        Placa = placa;
        Modelo = modelo;
        Cor = cor;
        CpfHospede = cpfHospede;
    }

    public static VeiculoInfo From(string placa, string modelo, string cor, string cpfHospede) 
        => new(Placa.From(placa), modelo, cor, CpfHospede.From(cpfHospede));
}
