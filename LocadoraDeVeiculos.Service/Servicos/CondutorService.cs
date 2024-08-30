using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;

namespace LocadoraDeVeiculos.Service.Servicos
{
    public class CondutorService
    {
        private readonly IRepositorioCondutor repositorioCondutor;

        public CondutorService(IRepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public Result<Condutor> Inserir(Condutor Condutor)
        {
            repositorioCondutor.Inserir(Condutor);

            return Result.Ok(Condutor);
        }

        public Result<Condutor> Editar(Condutor condutor)
        {
            var Condutor = repositorioCondutor.SelecionarPorId(condutor.Id);

            if (Condutor is null)
                return Result.Fail("O condutor não foi encontrado!");

            Condutor.Nome = condutor.Nome;


            repositorioCondutor.Editar(Condutor);

            return Result.Ok(Condutor);
        }

        public Result<Condutor> Excluir(int condutorId)
        {
            var Condutor = repositorioCondutor.SelecionarPorId(condutorId);

            if (Condutor is null)
                return Result.Fail("O Condutor não foi encontrado!");

            repositorioCondutor.Excluir(Condutor);

            return Result.Ok(Condutor);
        }

        public Result<Condutor> SelecionarPorId(int CondutorId)
        {
            var condutor = repositorioCondutor.SelecionarPorId(CondutorId);

            if (condutor is null)
                return Result.Fail("O Condutor não foi encontrado!");

            return Result.Ok(condutor);
        }

        public Result<List<Condutor>> SelecionarTodos(int usuarioId)
        {
            var condutores = repositorioCondutor
                .Filtrar(f => f.UsuarioId == usuarioId);

            return Result.Ok(condutores);
        }
    }
}
