using LocadoraDeVeiculos.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.Compartilhado;

public abstract class RepositorioBaseEmOrm<TEntidade> where TEntidade : EntidadeBase
{
    protected readonly LocadoraDbContext dbContext;

    public RepositorioBaseEmOrm(LocadoraDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    protected abstract DbSet<TEntidade> ObterRegistros();

    public void Inserir(TEntidade entidade)
    {
        ObterRegistros().Add(entidade);

        dbContext.SaveChanges();
    }

    public void Editar(TEntidade entidade)
    {
        ObterRegistros().Update(entidade);

        dbContext.SaveChanges();
    }

    public void Excluir(TEntidade entidade)
    {
        ObterRegistros().Remove(entidade);

        dbContext.SaveChanges();
    }

    public virtual TEntidade? SelecionarPorId(int id)
    {
        return ObterRegistros().FirstOrDefault(r => r.Id == id);
    }

    public virtual List<TEntidade> SelecionarTodos()
    {
        return ObterRegistros()
            .ToList();
    }
}