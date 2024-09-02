using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloPrecosCombustiveis;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Web.Dominio.ModuloUsuario;

namespace LocadoraDeVeiculos.Service.Servicos
{
    public class PrecosCombustiveisService
    {
        private readonly IRepositorioPrecosCombustiveis repositorioPrecosCombustiveis;

        public PrecosCombustiveisService(IRepositorioPrecosCombustiveis repositorioPrecosCombustiveis)
        {
            this.repositorioPrecosCombustiveis = repositorioPrecosCombustiveis;
        }
        public Result<PrecosCombustiveis> Inserir(PrecosCombustiveis precospadrao)
        {
            repositorioPrecosCombustiveis.Inserir(precospadrao);

            return Result.Ok(precospadrao);
        }
        public Result<PrecosCombustiveis> Editar(PrecosCombustiveis precoAtualizado)
        {
            var precosCombustiveis = repositorioPrecosCombustiveis.SelecionarPorId(precoAtualizado.Id);

            if (precosCombustiveis is null)
                return Result.Fail("O veículo não foi encontrado!");

            precosCombustiveis.PrecoGasolina = precoAtualizado.PrecoGasolina;
            precosCombustiveis.PrecoDiesel = precoAtualizado.PrecoDiesel;
            precosCombustiveis.PrecoGas = precoAtualizado.PrecoGas;
            precosCombustiveis.PrecoAlcool = precoAtualizado.PrecoAlcool;


            repositorioPrecosCombustiveis.Editar(precosCombustiveis);

            return Result.Ok(precosCombustiveis);
        }


        public Result<PrecosCombustiveis> SelecionarPorId(int precoId)
        {
            var precosCombustiveis = repositorioPrecosCombustiveis.SelecionarPorId(precoId);

            if (precosCombustiveis is null)
                return Result.Fail("O preço não foi encontrado!");

            return Result.Ok(precosCombustiveis);
        }

        public Result<List<PrecosCombustiveis>> SelecionarTodos(int usuarioId)
        {
            var precos
                = repositorioPrecosCombustiveis.Filtrar(f => f.UsuarioId == usuarioId);

            return Result.Ok(precos);
        }

    }
}
