using GestaoParaEstacionamento.Core.Dominio.ModuloRecepcao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoParaEstacionamento.Infraestrutura.ORM.ModuloRecepcao;
public class MapeadorEntrada : IEntityTypeConfiguration<Entrada>
{
    public void Configure(EntityTypeBuilder<Entrada> builder) {
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .IsRequired();

        // 1 coluna
        builder.OwnsOne(e => e.Ticket, ticket => {
            ticket.Property(t => t.Numero)
                .HasColumnName("Ticket")
                .HasColumnType("integer")
                .IsRequired();
        });

        builder.HasIndex(e => e.Ticket.Numero)
            .IsUnique();
    }
}
