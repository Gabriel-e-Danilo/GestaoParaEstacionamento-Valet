using GestaoParaEstacionamento.Core.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace GestaoParaEstacionamento.Infraestrutura.ORM.Compartilhado;
public sealed class TicketSequenciador : ITicketSequenciador
{
    private readonly AppDbContext dbContext;

    public TicketSequenciador(AppDbContext dbContext) {
        this.dbContext = dbContext;
    }

    public async Task<int> ProximoAsync() {
        var sql = "SELECT nextval('ticket_seq')::int";

        var numero = await dbContext.Database
            .SqlQueryRaw<int>(sql)
            .SingleAsync();

        return numero;
    }
}
