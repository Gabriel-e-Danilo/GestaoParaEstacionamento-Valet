using GestaoParaEstacionamento.Core.Dominio.Compartilhado;

namespace GestaoParaEstacionamento.Core.Dominio.ModuloEstacionamento;

public class VagaEstacionamento : EntidadeBase<VagaEstacionamento>
{
    public string Identificador { get; set; } = string.Empty; // ex: A-01
    public string Zona { get; set; } = "Geral";        // ex: A, VIP, Coberta

    public StatusVaga Status { get; set; } = StatusVaga.Livre;

    public int? TicketAtual { get; set; }
    public string? PlacaAtual { get; set; }

    private readonly List<LocacaoVaga> _locacoes = new();
    public IReadOnlyCollection<LocacaoVaga> Locacoes => _locacoes;

    public VagaEstacionamento() { }

    public VagaEstacionamento(string identificador, string zona) {
        Id = Guid.NewGuid();
        Identificador = identificador;
        Zona = zona;
        Status = StatusVaga.Livre;
    }

    public override void AtualizarRegistro(VagaEstacionamento editado) {
        Identificador = editado.Identificador;
        Zona = editado.Zona;
    }


    public LocacaoVaga Estacionar(int ticket, string placa, DateTime? momento = null) {

        if (Status == StatusVaga.Ocupada) throw new InvalidOperationException("Vaga já está ocupada.");

        if (string.IsNullOrWhiteSpace(placa)) throw new ArgumentException("Placa é obrigatória.");

        var loc = new LocacaoVaga(ticket, placa);

        if (momento is not null) {
            typeof(LocacaoVaga)
                .GetProperty(nameof(LocacaoVaga.DataHoraEntrada))!
                .SetValue(loc, momento.Value);
        }

        typeof(LocacaoVaga).GetProperty(nameof(LocacaoVaga.VagaId))!.SetValue(loc, Id);

        _locacoes.Add(loc);

        Status = StatusVaga.Ocupada;
        TicketAtual = ticket;
        PlacaAtual = placa;

        return loc;
    }

    public void DesocuparPorTicket(long ticket, DateTime? momento = null) {
        var ativa = _locacoes.LastOrDefault(l => l.Ativa && l.Ticket == ticket);
        if (ativa is null)
            throw new InvalidOperationException("Não há locação ativa com este ticket nesta vaga.");

        ativa.Encerrar(momento);
        Liberar();
    }

    public void DesocuparPorPlaca(string placa, DateTime? momento = null) {
        if (string.IsNullOrWhiteSpace(placa))
            throw new ArgumentException("Placa é obrigatória.");

        var ativa = _locacoes.LastOrDefault(l => l.Ativa && l.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
        if (ativa is null)
            throw new InvalidOperationException("Não há locação ativa com esta placa nesta vaga.");

        ativa.Encerrar(momento);
        Liberar();
    }

    public void EncerrarLocacaoPorTicket(long ticket, DateTime? momento = null) {
        var loc = _locacoes.LastOrDefault(l => l.Ativa && l.Ticket == ticket);

        if (loc is null) throw new InvalidOperationException("Locação não encontrada ou já encerrada para este ticket.");

        loc.Encerrar(momento);

        // se o ticket encerrado era o atual, liberar a vaga
        if (TicketAtual == ticket)
            Liberar();
    }

    private void Liberar() {
        Status = StatusVaga.Livre;
        TicketAtual = null;
        PlacaAtual = null;
    }

    public bool EstaLivre() => Status == StatusVaga.Livre;
    public bool EstaOcupada() => Status == StatusVaga.Ocupada;
}