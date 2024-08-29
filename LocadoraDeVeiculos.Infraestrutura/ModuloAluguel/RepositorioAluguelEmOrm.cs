using System;
using System.Collections.Generic;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;

public class RepositorioAluguelEmOrm : RepositorioBaseEmOrm<Aluguel>, IRepositorioAluguel
{
    public RepositorioAluguelEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Aluguel> ObterRegistros()
    {
        return dbContext.Alugueis;
    }

    public override Aluguel? SelecionarPorId(int id)
    {
        return ObterRegistros()
            .FirstOrDefault(v => v.Id == id);
    }

    public override List<Aluguel> SelecionarTodos()
    {
        return ObterRegistros()
            .ToList();
    }

    public List<Aluguel> Filtrar(Func<Aluguel, bool> predicate)
    {
        throw new NotImplementedException();
    }
}
