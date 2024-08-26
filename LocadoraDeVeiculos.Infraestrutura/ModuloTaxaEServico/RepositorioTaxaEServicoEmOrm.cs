using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloTaxaEServico;

namespace LocadoraDeVeiculos.Infraestrutura.ModuloTaxaEServico
{
    public class RepositorioTaxaEServicoEmOrm : RepositorioBaseEmOrm<TaxaEServico>, IRepositorioTaxaEServico
    {
        public RepositorioTaxaEServicoEmOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<TaxaEServico> ObterRegistros()
        {
            return dbContext.TaxasEServicos;
        }

        public override TaxaEServico? SelecionarPorId(int id)
        {
            return ObterRegistros()
                .FirstOrDefault(v => v.Id == id);
        }

        public override List<TaxaEServico> SelecionarTodos()
        {
            return ObterRegistros()
                .ToList();
        }

        public List<TaxaEServico> Filtrar(Func<TaxaEServico, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }

}
