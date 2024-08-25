using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloPrecosCombustiveis;

namespace LocadoraDeVeiculos.Infraestrutura.ModuloPrecosCombustiveis
{
    public class MapeadorPrecosCombustiveisEmOrm : IEntityTypeConfiguration<PrecosCombustiveis>
    {
        public void Configure(EntityTypeBuilder<PrecosCombustiveis> sBuilder)
        {
            sBuilder.ToTable("TBPrecosCombustiveis");

            sBuilder.Property(s => s.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            sBuilder.Property(s => s.PrecoGasolina)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            sBuilder.Property(s => s.PrecoDiesel)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            sBuilder.Property(s => s.PrecoGas)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            sBuilder.Property(s => s.PrecoAlcool)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");
        }


    }
}
