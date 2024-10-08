﻿using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloTaxaEServico;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraDeVeiculos.Service.Servicos
{
    public class TaxaEServicoService
    {
        private readonly IRepositorioTaxaEServico repositorioTaxaEServico;

        public TaxaEServicoService(IRepositorioTaxaEServico repositorioTaxaEServico)
        {
            this.repositorioTaxaEServico = repositorioTaxaEServico;
        }

        public Result<TaxaEServico> Inserir(TaxaEServico taxaEServico)
        {
            repositorioTaxaEServico.Inserir(taxaEServico);

            return Result.Ok(taxaEServico);
        }

        public Result<TaxaEServico> Editar(TaxaEServico TaxaEServicoAtualizado)
        {
            var taxaEServico = repositorioTaxaEServico.SelecionarPorId(TaxaEServicoAtualizado.Id);

            if (taxaEServico is null)
                return Result.Fail("A taxa ou serviço não foi encontrado!");

            taxaEServico.Nome = TaxaEServicoAtualizado.Nome;


            repositorioTaxaEServico.Editar(taxaEServico);

            return Result.Ok(taxaEServico);
        }

        public Result Excluir(int salaId)
        {
            var taxaEServico = repositorioTaxaEServico.SelecionarPorId(salaId);

            if (taxaEServico is null)
                return Result.Fail("A taxa ou serviço não foi encontrado!");

            repositorioTaxaEServico.Excluir(taxaEServico);

            return Result.Ok();
        }

        public Result<TaxaEServico> SelecionarPorId(int salaId)
        {
            var taxaEServico = repositorioTaxaEServico.SelecionarPorId(salaId);

            if (taxaEServico is null)
                return Result.Fail("A taxa ou serviço não foi encontrado!");

            return Result.Ok(taxaEServico);
        }

        public Result<List<TaxaEServico>> SelecionarTodos(int usuarioId)
        {
            var taxasEServicos = repositorioTaxaEServico
                .Filtrar(f => f.UsuarioId == usuarioId);

            return Result.Ok(taxasEServicos);
        }

        public List<TaxaEServico> SelecionarPorIdsObjetos(int[] Ids, Veiculo v)
        {
           List<TaxaEServico> taxaEServico = new List<TaxaEServico>();
            foreach (TaxaEServico t in repositorioTaxaEServico
                         .Filtrar(f => f.UsuarioId == v.UsuarioId))
            {
                for (int i = 0; i <Ids.Length; i++)
                {
                    if (Ids[i] == t.Id)
                    {
                        taxaEServico.Add(t);
                    }
                }
            }

            if (taxaEServico is null)
                return null;

            return taxaEServico;
        }
    }
}