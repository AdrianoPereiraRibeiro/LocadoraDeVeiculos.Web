using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloTaxaEServico;
using LocadoraDeVeiculos.Web.Dominio.ModuloPlanoCobranca;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase
    {
        public int ClienteId { get; set; }
        public Cliente Cliente{ get; set; }
        public int GrupoDeAutomoveisId { get; set; }
        public GrupoDeAutomoveis GrupoDeAutomoveis { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime? DataRetorno { get; set; }
        public decimal ValorEntrada { get; set; }
        public decimal? ValorTotal { get; set; }
       public int PlanoId { get; set; }
        public PlanoCobranca Plano { get; set; }
        public List<TaxaEServico>? TaxasEServicos { get; set; } = [];
        public bool AluguelAtivo { get; set; }

        protected Aluguel()
        {
        }

        public Aluguel(
            Cliente cliente,
            int clienteId,
            GrupoDeAutomoveis grupoDeAutomoveis,
            int grupoDeAutomoveisId,
            Veiculo veiculo,
            int veiculoId,
            DateTime dataSaida,
            DateTime dataRetorno,
            decimal valorEntrada,
            decimal valorTotal,
            PlanoCobranca plano,
            int planoId,
            List<TaxaEServico> taxasEServicos,
            bool aluguelAtivo
        )
        {
            Cliente = cliente;
            ClienteId = clienteId;
            GrupoDeAutomoveis = grupoDeAutomoveis;
            GrupoDeAutomoveisId = grupoDeAutomoveisId;
            Veiculo = veiculo;
            VeiculoId = veiculoId;
            DataSaida = dataSaida;
            DataRetorno = dataRetorno;
            ValorEntrada = valorEntrada;
            ValorTotal = valorTotal;
            Plano = plano;
            PlanoId = planoId;
            TaxasEServicos = taxasEServicos;
            AluguelAtivo = aluguelAtivo;

        }

        public override List<string> Validar()
        {
            List<string> erros = [];

            if (Cliente.Equals(null))
                erros.Add("O cliente é obrigatório");

            if (GrupoDeAutomoveis.Equals(null))
                erros.Add("O grupo de automóveis é obrigatório");

            if (Veiculo.Equals(null))
                erros.Add("O veículo é obrigatório");

            if (DataSaida.Equals(null))
                erros.Add("Uma data é obrigatória");

            if (ValorEntrada<0)
                erros.Add("O valor de entrada deve ser maior que zero!");

            if (ValorTotal>0)
                erros.Add("O valor total deve ser maior que zero!");

            if (Plano.Equals(null))
                erros.Add("O plano é obrigatório");
            return erros;
        }
    }
}
