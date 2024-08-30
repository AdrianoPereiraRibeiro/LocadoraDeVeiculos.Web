using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;

public class RepositorioClienteEmOrm : RepositorioBaseEmOrm<Cliente>, IRepositorioCliente
{
    public RepositorioClienteEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Cliente> ObterRegistros()
    {
        return dbContext.Clientes;
    }

    public override Cliente? SelecionarPorId(int id)
    {
        return ObterRegistros()
            .FirstOrDefault(v => v.Id == id);
    }

    public override List<Cliente> SelecionarTodos()
    {
        return ObterRegistros()
            .ToList();
    }

    public List<Cliente> Filtrar(Func<Cliente, bool> predicate)
    {
        return ObterRegistros()
            .Where(predicate)
            .ToList();
    }
}
