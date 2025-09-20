namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;
public sealed record class CpfHospede
{
    public string Numeros { get; }
    private CpfHospede(string numeros) => Numeros = numeros;

    public static CpfHospede From(string entrada) {
        var norm = (entrada ?? string.Empty)
            .Trim()
            .Replace(".", "")
            .Replace("-", "")
            .Replace(" ", "");
        return new CpfHospede(norm);
    }

    public override string ToString() 
        => Numeros.Length == 11
            ? $"{Numeros[..3]}.{Numeros.Substring(3, 3)}.{Numeros.Substring(6, 3)}-{Numeros[9..]}"
            : Numeros;
}
