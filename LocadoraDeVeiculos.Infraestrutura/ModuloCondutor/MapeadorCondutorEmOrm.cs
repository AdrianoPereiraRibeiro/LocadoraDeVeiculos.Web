using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleCinema.Infra.Orm.ModuloSala;

public class MapeadorCondutorEmOrm : IEntityTypeConfiguration<Condutor>
{
    public void Configure(EntityTypeBuilder<Condutor> sBuilder)
    {
        sBuilder.ToTable("TBCondutor");

        sBuilder.Property(s => s.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        sBuilder.Property(s => s.ClienteEqualsCondutor)
            .IsRequired()
            .HasColumnType("varchar(200)");

        sBuilder.Property(s => s.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        sBuilder.Property(s => s.Email)
            .IsRequired()
            .HasColumnType("varchar(200)");

        sBuilder.Property(s => s.Telefone)
            .IsRequired()
            .HasColumnType("varchar(200)");

        sBuilder.Property(s => s.CPF)
            .IsRequired()
            .HasColumnType("varchar(200)");

        sBuilder.Property(s => s.CNH)
            .IsRequired()
            .HasColumnType("varchar(200)");

        sBuilder.Property(s => s.Validade)
            .IsRequired()
            .HasColumnType("datetime");

        sBuilder.Property(v => v.ClienteId)
            .HasColumnType("int")
            .IsRequired();

        sBuilder.HasOne(v => v.Cliente)
            .WithMany()
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);
    }


}