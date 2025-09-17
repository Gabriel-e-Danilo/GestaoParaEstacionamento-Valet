using GestaoParaEstacionamento.Core.Dominio.Compartilhado;

namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
public interface IRepositorioCheckin : IRepositorio<CheckinVeiculo>
{
    Task<bool> ExisteTicketAsync(long ticket);
}
