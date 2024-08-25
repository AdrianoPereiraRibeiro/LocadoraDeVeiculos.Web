using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPrecosCombustiveis
{
    public class PrecosCombustiveis : EntidadeBase
    {
        public decimal PrecoGasolina { get; set; }
        public decimal PrecoDiesel { get; set; }
        public decimal PrecoGas { get; set; }
        public decimal PrecoAlcool { get; set; }
        public override List<string> Validar()
        {
            List<string> erros = [];

            if (PrecoGasolina <= 0)
                erros.Add("O valor digitado é inválido!");
            if (PrecoDiesel <= 0)
                erros.Add("O valor digitado é inválido!");
            if (PrecoGas <= 0)
                erros.Add("O valor digitado é inválido!");
            if (PrecoAlcool <= 0)
                erros.Add("O valor digitado é inválido!");




            return erros;
        }
    }
}
