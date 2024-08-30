using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;

public class MapeadorCliente : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("TBCliente");

        builder.Property(v => v.Id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(v => v.Nome)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(v => v.Email)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(v => v.Telefone)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(v => v.TipoPessoa)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(v => v.CPF)
            .HasColumnType("varchar(100)");

        builder.Property(v => v.CNPJ)
            .HasColumnType("varchar(100)");

        builder.Property(v => v.Estado)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(v => v.Cidade)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(v => v.Bairro)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(v => v.Rua)
            .HasColumnType("varchar(100)")
            .IsRequired();
        
        builder.Property(v => v.Numero)
            .HasColumnType("varchar(100)")
            .IsRequired();

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
