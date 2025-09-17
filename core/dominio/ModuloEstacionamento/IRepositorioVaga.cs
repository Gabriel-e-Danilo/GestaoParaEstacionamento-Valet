using GestaoParaEstacionamento.Core.Dominio.Compartilhado;

namespace GestaoParaEstacionamento.Core.Dominio.ModuloEstacionamento;
public interface IRepositorioVaga : IRepositorio<VagaEstacionamento>
{
    Task<VagaEstacionamento?> SelecionarPorIdentificadorAsync(string identificador);

    Task<List<VagaEstacionamento>> SelecionarTodasAsync();
    Task<List<VagaEstacionamento>> SelecionarLivresAsync();
    Task<List<VagaEstacionamento>> SelecionarOcupadasAsync();

    Task<VagaEstacionamento?> SelecionarPorTicketAtivoAsync(long ticket);
    Task<VagaEstacionamento?> SelecionarPorPlacaAtivaAsync(string placa);

    Task<List<(string Placa, long Ticket, string IdentificadorVaga, string Zona, DateTime DataHoraEntrada)>>
    ListarVeiculosEstacionadosAsync(string? placaFiltro = null);
}
