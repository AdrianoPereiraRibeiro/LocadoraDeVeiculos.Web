using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleCinema.Infra.Orm.ModuloSala;

public class RepositorioGrupoDeVeiculosEmOrm :
    RepositorioBaseEmOrm<GrupoDeAutomoveis>, IRepositorioGrupoDeAutomoveis
{
    public RepositorioGrupoDeVeiculosEmOrm(
        LocadoraDbContext dbContext) : base(dbContext) { }

    protected override DbSet<GrupoDeAutomoveis> ObterRegistros()
    {
        return dbContext.GrupoDeAutomoveis;
    }

    public List<GrupoDeAutomoveis> Filtrar(Func<GrupoDeAutomoveis, bool> predicate)
    {
        return ObterRegistros()
            .Where(predicate)
            .ToList();
    }
}