namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;

public sealed record class Ticket(
    int Numero
)
{
    public string GerarCodigo => $"T-{Numero:0000}";
    public override string ToString() => GerarCodigo;

    public static Ticket From(int numero) => new(numero);
}
