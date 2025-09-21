using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
using GestaoParaEstacionamento.Infraestrutura.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace GestaoParaEstacionamento.Infraestrutura.ORM.ModuloRecepcao;
public class RepositorioEntradaEmORM(AppDbContext contexto)
    : RepositorioBaseEmOrm<Entrada>(contexto), IRepositorioEntrada
{
    public async Task<Entrada?> SelecionarPorTicketAsync(int ticketNumero, CancellationToken cancellationToken = default) {
        return await registros
                .AsNoTracking()
                .SingleOrDefaultAsync(e => e.Ticket.Numero == ticketNumero, cancellationToken);
    }
}
