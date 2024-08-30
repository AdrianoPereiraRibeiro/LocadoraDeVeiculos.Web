using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloAluguel;

public class MapeadorAluguel : IEntityTypeConfiguration<Aluguel>
{
    public void Configure(EntityTypeBuilder<Aluguel> builder)
    {
        builder.ToTable("TBCliente");

        builder.Property(v => v.Id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(v => v.ClienteId)
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(v => v.Cliente)
            .WithMany()
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);
       
        builder.Property(v => v.GrupoDeAutomoveisId)
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(v => v.GrupoDeAutomoveis)
            .WithMany()
            .HasForeignKey(v => v.GrupoDeAutomoveisId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(v => v.VeiculoId)
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(v => v.Veiculo)
            .WithMany()
            .HasForeignKey(v => v.VeiculoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(s => s.DataSaida)
            .IsRequired()
            .HasColumnType("datetime");
        
        builder.Property(s => s.DataRetorno)
            .HasColumnType("datetime");

        builder.Property(s => s.ValorEntrada)
            .IsRequired()
            .HasColumnType("decimal(18, 2)");

        builder.Property(s => s.ValorTotal)
            .HasColumnType("decimal(18, 2)");

        builder.Property(v => v.PlanoId)
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(v => v.Plano)
            .WithMany()
            .HasForeignKey(v => v.PlanoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.TaxasEServicos)
            .WithMany();

        builder.Property(v => v.AluguelAtivo)
            .IsRequired()
            .HasColumnType("bit");
    }
}
