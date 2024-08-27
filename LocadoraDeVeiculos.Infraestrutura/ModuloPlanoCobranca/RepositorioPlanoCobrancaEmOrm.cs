using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Web.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Web.Infra.Orm.ModuloPlanoCobranca;

public class RepositorioPlanoCobrancaEmOrm : RepositorioBaseEmOrm<PlanoCobranca>, IRepositorioPlanoCobranca
{
    public RepositorioPlanoCobrancaEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<PlanoCobranca> ObterRegistros()
    {
        return dbContext.PlanosCobrancas;
    }

    public override PlanoCobranca? SelecionarPorId(int id)
    {
        return ObterRegistros()
            .Include(p => p.GrupoDeAutomoveis)
            .FirstOrDefault(p => p.Id == id);
    }

    public override List<PlanoCobranca> SelecionarTodos()
    {
        return ObterRegistros()
            .Include(p => p.GrupoDeAutomoveis)
            .AsNoTracking()
            .ToList();
    }

    public List<PlanoCobranca> Filtrar(Func<PlanoCobranca, bool> predicate)
    {
        throw new NotImplementedException();
    }
}
