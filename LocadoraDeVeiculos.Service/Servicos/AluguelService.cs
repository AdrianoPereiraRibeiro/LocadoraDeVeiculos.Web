using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Service.Servicos
{
    public class AluguelService
    {
        private readonly IRepositorioAluguel repositorioAluguel;

        public AluguelService(IRepositorioAluguel repositorioAluguel)
        {
            this.repositorioAluguel = repositorioAluguel;
        }

        public Result<Aluguel> Inserir(Aluguel aluguel)
        {
            repositorioAluguel.Inserir(aluguel);

            return Result.Ok(aluguel);
        }

        public Result<Aluguel> Editar(Aluguel aluguelAtualizado)
        {
            var aluguel = repositorioAluguel.SelecionarPorId(aluguelAtualizado.Id);

            if (aluguel is null)
                return Result.Fail("O aluguel não foi encontrado!");

            aluguel.Cliente = aluguelAtualizado.Cliente;
            aluguel.GrupoDeAutomoveis= aluguelAtualizado.GrupoDeAutomoveis;
            aluguel.Veiculo = aluguelAtualizado.Veiculo;
            aluguel.DataSaida = aluguelAtualizado.DataSaida;
            aluguel.DataRetorno = aluguelAtualizado.DataRetorno;
            aluguel.ValorEntrada = aluguelAtualizado.ValorEntrada;
            aluguel.ValorTotal = aluguelAtualizado.ValorTotal;
            aluguel.Plano = aluguelAtualizado.Plano;
            aluguel.TaxasEServicos = aluguelAtualizado.TaxasEServicos;

            repositorioAluguel.Editar(aluguel);

            return Result.Ok(aluguel);
        }

        public Result<Aluguel> Excluir(int aluguelId)
        {
            var aluguel = repositorioAluguel.SelecionarPorId(aluguelId);

            if (aluguel is null)
                return Result.Fail("O aluguel não foi encontrado!");

            repositorioAluguel.Excluir(aluguel);

            return Result.Ok(aluguel);
        }

        public Result<Aluguel> SelecionarPorId(int aluguelId)
        {
            var aluguel = repositorioAluguel.SelecionarPorId(aluguelId);

            if (aluguel is null)
                return Result.Fail("O aluguel não foi encontrado!");

            return Result.Ok(aluguel);
        }

        public Result<List<Aluguel>> SelecionarTodos()
        {
            var aluguels = repositorioAluguel.SelecionarTodos();

            return Result.Ok(aluguels);
        }



    }
}


