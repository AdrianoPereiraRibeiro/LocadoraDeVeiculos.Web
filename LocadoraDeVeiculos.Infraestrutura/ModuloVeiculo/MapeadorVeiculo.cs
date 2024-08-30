using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;

public class MapeadorVeiculo : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.ToTable("TBVeiculo");

        builder.Property(v => v.Id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(v => v.Modelo)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(v => v.Marca)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(v => v.TipoCombustivel)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(v => v.CapacidadeTanque)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(v => v.GrupoDeAutomoveisId)
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(v => v.GrupoDeAutomoveis)
            .WithMany(g => g.Veiculos)
            .HasForeignKey(v => v.GrupoDeAutomoveisId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(s => s.UsuarioId)
            .IsRequired()
            .HasColumnType("int")
            .HasColumnName("Usuario_Id");

        builder.HasOne(g => g.Usuario)
            .WithMany()
            .HasForeignKey(s => s.UsuarioId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
