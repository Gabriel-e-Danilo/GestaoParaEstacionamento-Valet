using Microsoft.EntityFrameworkCore;

namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;

[Owned]
public sealed record class VeiculoInfo(
    Placa Placa,
    string Modelo,
    string Cor,
    CpfHospede CpfHospede
)
{ 
    public static VeiculoInfo From(string placa, string modelo, string cor, string cpfHospede) 
        => new(Placa.From(placa), modelo, cor, CpfHospede.From(cpfHospede));
}
