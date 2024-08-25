using LocadoraDeVeiculos.Dominio.ModuloCondutor;

using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infraestrutura;

public class RepositorioCondutorEmOrm :
    RepositorioBaseEmOrm<Condutor>, IRepositorioCondutor
{
    public RepositorioCondutorEmOrm(
        LocadoraDbContext dbContext) : base(dbContext) { }

    protected override DbSet<Condutor> ObterRegistros()
    {
        return dbContext.Condutores;
    }


    public List<Condutor> Filtrar(Func<Condutor, bool> predicate)
    {
        throw new NotImplementedException();
    }
}