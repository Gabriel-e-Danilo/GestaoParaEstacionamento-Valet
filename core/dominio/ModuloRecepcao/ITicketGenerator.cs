namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
public interface ITicketGenerator
{
    Task<long> ProximoAsync();
}
