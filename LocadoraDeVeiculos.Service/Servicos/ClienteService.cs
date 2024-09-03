using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.Service.Servicos
{
    public class ClienteService
    {
        private readonly IRepositorioCliente repositorioCliente;

        public ClienteService(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public Result<Cliente> Inserir(Cliente cliente)
        {
            repositorioCliente.Inserir(cliente);

            return Result.Ok(cliente);
        }

        public Result<Cliente> Editar(Cliente clienteAtualizado)
        {
            var cliente = repositorioCliente.SelecionarPorId(clienteAtualizado.Id);

            if (cliente is null)
                return Result.Fail("O veículo não foi encontrado!");

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Email = clienteAtualizado.Email;
            cliente.Telefone = clienteAtualizado.Telefone;
            cliente.TipoPessoa = clienteAtualizado.TipoPessoa;
            cliente.CPF = clienteAtualizado.CPF;
            cliente.CNPJ = clienteAtualizado.CNPJ;
            cliente.Estado = clienteAtualizado.Estado;
            cliente.Cidade = clienteAtualizado.Cidade;
            cliente.Bairro = clienteAtualizado.Bairro;
            cliente.Rua = clienteAtualizado.Rua;
            cliente.Numero= clienteAtualizado.Numero;

            repositorioCliente.Editar(cliente);

            return Result.Ok(cliente);
        }

        public Result<Cliente> Excluir(int clienteId)
        {
            var cliente = repositorioCliente.SelecionarPorId(clienteId);

            if (cliente is null)
                return Result.Fail("O cliente não foi encontrado!");

            repositorioCliente.Excluir(cliente);

            return Result.Ok(cliente);
        }

        public Result<Cliente> SelecionarPorId(int clienteId)
        {
            var cliente = repositorioCliente.SelecionarPorId(clienteId);

            if (cliente is null)
                return Result.Fail("O cliente não foi encontrado!");

            return Result.Ok(cliente);
        }

        public Result<List<Cliente>> SelecionarTodos(int usuarioId)
        {
            var clientes = repositorioCliente
                .Filtrar(f => f.UsuarioId == usuarioId);

            return Result.Ok(clientes);
        }

        public Cliente SelecionarPorIdObjeto(int clienteId)
        {
            var cliente = repositorioCliente.SelecionarPorId(clienteId);

            if (cliente is null)
                return null;

            return cliente;
        }


    }
}

