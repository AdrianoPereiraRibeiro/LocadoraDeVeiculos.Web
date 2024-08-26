using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloTaxaEServico;

namespace LocadoraDeVeiculos.Infraestrutura.ModuloTaxaEServico
{
    public class MapeadorTaxaEServicoEmOrm : IEntityTypeConfiguration<TaxaEServico>
    {
        public void Configure(EntityTypeBuilder<TaxaEServico> sBuilder)
        {
            sBuilder.ToTable("TBTaxasEServicos");

            sBuilder.Property(s => s.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            sBuilder.Property(s => s.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            sBuilder.Property(s => s.FixoOuDiario)
                .IsRequired()
                .HasColumnType("int");

            sBuilder.Property(s => s.Preco)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

        }


    }
}
