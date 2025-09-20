namespace GestaoParaEstacionamento.Core.Dominio.Compartilhado;
public interface ITicketSequenciador
{
    Task<int> ProximoAsync();
}
