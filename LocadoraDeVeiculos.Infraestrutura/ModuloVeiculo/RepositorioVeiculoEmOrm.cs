using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;

public class RepositorioVeiculoEmOrm : RepositorioBaseEmOrm<Veiculo>, IRepositorioVeiculo
{
    public RepositorioVeiculoEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Veiculo> ObterRegistros()
    {
        return dbContext.Veiculos;
    }

    public override Veiculo? SelecionarPorId(int id)
    {
        return ObterRegistros()
            .Include(v => v.GrupoDeAutomoveis)
            .FirstOrDefault(v => v.Id == id);
    }

    public override List<Veiculo> SelecionarTodos()
    {
        return ObterRegistros()
            .Include(v => v.GrupoDeAutomoveis)
            .ToList();
    }

    public List<Veiculo> Filtrar(Func<Veiculo, bool> predicate)
    {
        return ObterRegistros()
            .Where(predicate)
            .ToList();
    }
}
