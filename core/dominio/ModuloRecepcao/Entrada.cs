using GestaoParaEstacionamento.Core.Dominio.Compartilhado;
using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;

namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
public class Entrada : EntidadeBase<Entrada>
{
    public Ticket Ticket { get; set; }
    public VeiculoInfo Veiculo { get; set; } = null!;
    public string? Observacoes { get; set; }
    public DateTime DataHoraEntrada { get; set; } = DateTime.UtcNow;

    protected Entrada() { }

    private Entrada(Ticket ticket, VeiculoInfo veiculo, string? observacoes = null)
    {
        Id = Guid.NewGuid();
        Ticket = ticket;
        Veiculo = veiculo;
        Observacoes = observacoes;
        DataHoraEntrada = DateTime.UtcNow;
    }

    public static Entrada Criar(Ticket ticket, VeiculoInfo veiculo, string? observacoes = null)
        => new(ticket, veiculo, observacoes);

    public void DefinirObservacoes(string? texto)
        => Observacoes = string.IsNullOrWhiteSpace(texto) ? null : texto.Trim();

    public override void AtualizarRegistro(Entrada registroEditado) {
        throw new NotImplementedException();
    }
}
