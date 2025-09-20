using Microsoft.EntityFrameworkCore;

namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;


public sealed record class Ticket(
    int Numero
)
{
    public override string ToString() => Numero.ToString();
    public static Ticket From(int numero) => new(numero);
}
