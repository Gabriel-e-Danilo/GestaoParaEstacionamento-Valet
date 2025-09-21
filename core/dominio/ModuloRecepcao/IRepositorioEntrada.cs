using GestaoParaEstacionamento.Core.Dominio.Compartilhado;

namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
public interface IRepositorioEntrada : IRepositorio<Entrada>
{
    Task<Entrada?> SelecionarPorTicketAsync(int ticketNumero, CancellationToken cancellationToken = default);
}