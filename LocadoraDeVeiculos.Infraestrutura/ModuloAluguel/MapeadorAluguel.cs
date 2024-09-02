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
        builder.ToTable("TBAluguel");

        builder.Property(v => v.Id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasOne(s => s.Cliente)
            .WithMany()
            .HasForeignKey("Cliente_Id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Condutor)
            .WithMany()
            .HasForeignKey("Condutor_Id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.GrupoDeAutomoveis)
            .WithMany()
            .HasForeignKey("GrupoDeAutomoveis_Id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Veiculo)
            .WithMany()
            .HasForeignKey("Veiculo_Id")
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

        builder.HasOne(s => s.Plano)
            .WithMany()
            .HasForeignKey("Plano_Id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.TaxasEServicos)
            .WithMany();

        builder.Property(v => v.AluguelAtivo)
            .IsRequired()
            .HasColumnType("bit");

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
