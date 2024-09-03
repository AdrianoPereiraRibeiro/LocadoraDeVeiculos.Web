using FluentResults;
using LocadoraDeVeiculos.Web.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Web.Dominio.ModuloUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraDeVeiculos.Service.Servicos
{
    public class PlanoCobrancaService
    {
        private readonly IRepositorioPlanoCobranca repositorioPlanoCobranca;

        public PlanoCobrancaService(IRepositorioPlanoCobranca repositorioPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        public Result<PlanoCobranca> Inserir(PlanoCobranca planoCobranca)
        {
            repositorioPlanoCobranca.Inserir(planoCobranca);

            return Result.Ok(planoCobranca);
        }

        public Result<PlanoCobranca> Editar(PlanoCobranca planoCobrancaAtualizado)
        {
            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaAtualizado.Id);

            if (planoCobranca is null)
                return Result.Fail("O plano de cobrança não foi encontrado!");

            planoCobranca.GrupoDeAutomoveisId = planoCobrancaAtualizado.GrupoDeAutomoveisId;
            planoCobranca.PrecoDiarioPlanoDiario = planoCobrancaAtualizado.PrecoDiarioPlanoDiario;
            planoCobranca.PrecoQuilometroPlanoDiario = planoCobrancaAtualizado.PrecoQuilometroPlanoDiario;
            planoCobranca.QuilometrosDisponiveisPlanoControlado = planoCobrancaAtualizado.QuilometrosDisponiveisPlanoControlado;
            planoCobranca.PrecoDiarioPlanoControlado = planoCobrancaAtualizado.PrecoDiarioPlanoControlado;
            planoCobranca.PrecoQuilometroExtrapoladoPlanoControlado = planoCobrancaAtualizado.PrecoQuilometroExtrapoladoPlanoControlado;
            planoCobranca.PrecoDiarioPlanoLivre = planoCobrancaAtualizado.PrecoDiarioPlanoLivre;

            repositorioPlanoCobranca.Editar(planoCobranca);

            return Result.Ok(planoCobranca);
        }

        public Result<PlanoCobranca> Excluir(int planoCobrancaId)
        {
            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaId);

            if (planoCobranca is null)
                return Result.Fail("O plano de cobrança não foi encontrado!");

            repositorioPlanoCobranca.Excluir(planoCobranca);

            return Result.Ok(planoCobranca);
        }

        public Result<PlanoCobranca> SelecionarPorId(int planoCobrancaId)
        {
            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaId);

            if (planoCobranca is null)
                return Result.Fail("O plano de cobrança não foi encontrado!");

            return Result.Ok(planoCobranca);
        }

        public Result<List<PlanoCobranca>> SelecionarTodos(int usuarioId)
        {
            var planosCobranca = repositorioPlanoCobranca
                .Filtrar(f => f.UsuarioId == usuarioId);

            return Result.Ok(planosCobranca);
        }

        public PlanoCobranca SelecionarObjeto(Veiculo veiculo)
        {
            var planosCobranca = repositorioPlanoCobranca
                .Filtrar(f => f.UsuarioId == veiculo.UsuarioId);
            PlanoCobranca planoCobranca = null;

            foreach (PlanoCobranca p in planosCobranca )
            {
                if (veiculo.GrupoDeAutomoveisId == p.GrupoDeAutomoveisId)
                {
                     planoCobranca = p;
                }

            }

            if (planoCobranca is null)
                return null;

            return planoCobranca;
        }


    }

}
