using GestaoParaEstacionamento.Core.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoParaEstacionamento.Infraestrutura.ORM.ModuloVeiculo;
public class MapeadorVeiculo : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder) {

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Placa)
            .HasMaxLength(10)
            .IsRequired();

        builder.HasIndex(x => x.Placa)
            .IsUnique();

        builder.Property(x => x.Modelo)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Cor)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.CpfHospede)
            .HasMaxLength(14)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();
    }
}
