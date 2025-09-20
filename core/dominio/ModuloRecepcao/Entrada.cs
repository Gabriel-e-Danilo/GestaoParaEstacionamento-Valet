using GestaoParaEstacionamento.Core.Dominio.Compartilhado;
using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao.ValueObjects;

namespace GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
public class Entrada : EntidadeBase<Entrada>
{
    public Ticket Ticket { get; private set; } = null!;
    public VeiculoInfo Veiculo { get; private set; } = null!;
    public string? Observacoes { get; private set; }
    public DateTime DataHoraEntrada { get; private set; }

    protected Entrada() { }

    private Entrada(VeiculoInfo veiculo, string? observacoes = null)
    {
        Id = Guid.NewGuid();
        Veiculo = veiculo;
        Observacoes = observacoes;
        DataHoraEntrada = DateTime.UtcNow;
    }

    public static Entrada Criar(VeiculoInfo veiculo, string? observacoes = null)
        => new(veiculo, observacoes);

    public void DefinirObservacoes(string? texto)
        => Observacoes = string.IsNullOrWhiteSpace(texto) ? null : texto.Trim();

    public override void AtualizarRegistro(Entrada registroEditado) {
        throw new NotImplementedException();
    }
}
