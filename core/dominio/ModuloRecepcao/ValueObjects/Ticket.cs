namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;
public readonly record struct Ticket(
    int Numero
)
{
    public override string ToString() => Numero.ToString();
    public static Ticket From(int numero) => new(numero);
}
