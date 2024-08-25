using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloPrecosCombustiveis;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infraestrutura.ModuloPrecosCombustiveis
{
    public class RepositorioPrecoCombustiveisEmOrm :
        RepositorioBaseEmOrm<PrecosCombustiveis>, IRepositorioPrecosCombustiveis
    {
        public RepositorioPrecoCombustiveisEmOrm(
            LocadoraDbContext dbContext) : base(dbContext) { }

        protected override DbSet<PrecosCombustiveis> ObterRegistros()
        {
            return dbContext.PrecosCombustiveis;
        }

        public List<PrecosCombustiveis> Filtrar(Func<PrecosCombustiveis, bool> predicate)
        {
            return ObterRegistros()
                .Where(predicate)
                .ToList();
        }
    }
}
