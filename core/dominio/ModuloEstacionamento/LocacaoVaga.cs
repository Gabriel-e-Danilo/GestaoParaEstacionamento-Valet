using GestaoParaEstacionamento.Core.Dominio.Compartilhado;

namespace GestaoParaEstacionamento.Core.Dominio.ModuloEstacionamento;

public class LocacaoVaga : EntidadeBase<LocacaoVaga>
{
    public Guid VagaId { get; set; }

    public int Ticket { get; set; }
    public string Placa { get; set; } = null!;

    public DateTime DataHoraEntrada { get; set; } = DateTime.UtcNow;
    public DateTime? DataHoraSaida { get; set; }

    public bool Ativa => DataHoraSaida is null;

    public LocacaoVaga() { }

    public LocacaoVaga(int ticket, string placa) {
        Id = Guid.NewGuid();
        Ticket = ticket;
        Placa = placa;
    }

    internal void Encerrar(DateTime? momento = null) {

        if (!Ativa) return;

        DataHoraSaida = momento ?? DateTime.UtcNow;
    }
}