using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleCinema.Infra.Orm.ModuloSala;

public class MapeadorGrupoDeVeiculosEmOrm : IEntityTypeConfiguration<GrupoDeAutomoveis>
{
    public void Configure(EntityTypeBuilder<GrupoDeAutomoveis> sBuilder)
    {
        sBuilder.ToTable("TBGrupoDeAutomoveis");

        sBuilder.Property(s => s.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        sBuilder.Property(s => s.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        sBuilder.Property(s => s.UsuarioId)
            .IsRequired()
            .HasColumnType("int")
            .HasColumnName("Usuario_Id");

        sBuilder.HasOne(g => g.Usuario)
            .WithMany()
            .HasForeignKey(s => s.UsuarioId)
            .OnDelete(DeleteBehavior.NoAction);
    }


}