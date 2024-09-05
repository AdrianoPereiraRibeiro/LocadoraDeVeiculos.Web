using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Web.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Web.Dominio.ModuloUsuario;

namespace LocadoraDeVeiculos.Web.Service.Servicos
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

        public Result<Aluguel> RealizarDevolucao(Aluguel aluguelParaDevolucao)
        {
            if (aluguelParaDevolucao.DataRetorno is not null)
                return Result.Fail("A devolução já foi realizada!");

            aluguelParaDevolucao.DataRetorno = DateTime.Now;
            aluguelParaDevolucao.AluguelAtivo = false;
            

            repositorioAluguel.Editar(aluguelParaDevolucao);

            return Result.Ok(aluguelParaDevolucao);
        }

        public Result<Aluguel> Editar(Aluguel aluguelAtualizado)
        {
            var aluguel = repositorioAluguel.SelecionarPorId(aluguelAtualizado.Id);

            if (aluguel is null)
                return Result.Fail("O aluguel não foi encontrado!");

            aluguel.Cliente = aluguelAtualizado.Cliente;
            aluguel.Condutor = aluguelAtualizado.Condutor;
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

        public Aluguel SelecionarPorIdObjeto(int aluguelId)
        {
            var aluguel = repositorioAluguel.SelecionarPorId(aluguelId);

            if (aluguel is null)
                return null;

            return aluguel;
        }
        public Result<List<Aluguel>> SelecionarTodos(int usuarioId)
        {
            var aluguels = repositorioAluguel.Filtrar(f => f.UsuarioId == usuarioId); ;

            return Result.Ok(aluguels);
        }
      


    }
}


