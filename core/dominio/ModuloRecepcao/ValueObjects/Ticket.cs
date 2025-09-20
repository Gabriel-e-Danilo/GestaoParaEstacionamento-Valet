namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;

public sealed record class Ticket
{
    public int Numero { get; private init; }

    private Ticket() { }

    private Ticket(int numero) => Numero = numero;

    public static Ticket From(int numero) => new(numero);


    public string GerarCodigo => $"T-{Numero:D4}";
    public override string ToString() => GerarCodigo;
}
