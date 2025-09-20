namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;
public record class Placa
{
    public string Valor { get; }
    private Placa(string valor) => Valor = valor;

    public static Placa From(string entrada) {
        var norm = (entrada ?? string.Empty)
            .Trim()
            .ToUpperInvariant()
            .Replace("-", "")
            .Replace(" ", "");

        return new Placa(norm);
    }

    public override string ToString() => Valor;
}
