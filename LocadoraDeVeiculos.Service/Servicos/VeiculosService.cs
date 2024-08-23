using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Service.Servicos
{
    public class VeiculoService
    {
        private readonly IRepositorioVeiculo repositorioVeiculo;

        public VeiculoService(IRepositorioVeiculo repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public Result<Veiculo> Inserir(Veiculo veiculo)
        {
            repositorioVeiculo.Inserir(veiculo);

            return Result.Ok(veiculo);
        }

        public Result<Veiculo> Editar(Veiculo veiculoAtualizado)
        {
            var veiculo = repositorioVeiculo.SelecionarPorId(veiculoAtualizado.Id);

            if (veiculo is null)
                return Result.Fail("O veículo não foi encontrado!");

            veiculo.Modelo = veiculoAtualizado.Modelo;
            veiculo.Marca = veiculoAtualizado.Marca;
            veiculo.TipoCombustivel = veiculoAtualizado.TipoCombustivel;
            veiculo.CapacidadeTanque = veiculoAtualizado.CapacidadeTanque;
            veiculo.GrupoDeAutomoveisId = veiculoAtualizado.GrupoDeAutomoveisId;

            repositorioVeiculo.Editar(veiculo);

            return Result.Ok(veiculo);
        }

        public Result<Veiculo> Excluir(int veiculoId)
        {
            var veiculo = repositorioVeiculo.SelecionarPorId(veiculoId);

            if (veiculo is null)
                return Result.Fail("O veículo não foi encontrado!");

            repositorioVeiculo.Excluir(veiculo);

            return Result.Ok(veiculo);
        }

        public Result<Veiculo> SelecionarPorId(int veiculoId)
        {
            var veiculo = repositorioVeiculo.SelecionarPorId(veiculoId);

            if (veiculo is null)
                return Result.Fail("O veículo não foi encontrado!");

            return Result.Ok(veiculo);
        }

        public Result<List<Veiculo>> SelecionarTodos()
        {
            var veiculos = repositorioVeiculo.SelecionarTodos();

            return Result.Ok(veiculos);
        }

        //public byte[] CarregarImagem(string caminhoArquivo)
        //{
        //    return File.ReadAllBytes(caminhoArquivo);
        //}

        //public void SalvarImagem(byte[] imagem, string caminhoArquivo)
        //{
        //    File.WriteAllBytes(caminhoArquivo, imagem);
        //}

    }
}
