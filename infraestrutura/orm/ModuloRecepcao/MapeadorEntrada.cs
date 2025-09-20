using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoParaEstacionamento.Infraestrutura.ORM.ModuloRecepcao;
public class MapeadorEntrada : IEntityTypeConfiguration<Entrada>
{
    public void Configure(EntityTypeBuilder<Entrada> builder) {

        builder.ToTable("Tb_Entrada");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("Id")
            .ValueGeneratedNever()
            .IsRequired();

        // 1 coluna
        builder.OwnsOne(e => e.Ticket, tk => {

            tk.Property(t => t.Numero)
                .HasColumnName("Ticket")
                .IsRequired();
        });

        builder.HasIndex(e => e.Ticket.Numero)
            .HasDatabaseName("IX_Entrada_Ticket")
            .IsUnique();

        builder.OwnsOne(e => e.Veiculo, v => {

            v.OwnsOne(vi => vi.Placa, p => {

                p.Property(pp => pp.Valor)
                    .HasColumnName("Veiculo_Placa")
                    .HasMaxLength(10)
                    .IsRequired();

            });

            v.Property(vi => vi.Modelo)
                .HasColumnName("Veiculo_Modelo")
                .HasMaxLength(50)
                .IsRequired();

            v.Property(vi => vi.Cor)
                .HasColumnName("Veiculo_Cor")
                .HasMaxLength(30)
                .IsRequired();

            v.OwnsOne(vi => vi.CpfHospede, c => {
                c.Property(cc => cc.Numeros)
                    .HasColumnName("Veiculo_CpfHospede")
                    .HasMaxLength(14)
                    .IsRequired();
            });
        });

        builder.Property(e => e.Observacoes)
            .HasColumnName("Observacoes")
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(e => e.DataHoraEntrada)
            .HasColumnName("DataHoraEntrada")
            .IsRequired();
    }
}
