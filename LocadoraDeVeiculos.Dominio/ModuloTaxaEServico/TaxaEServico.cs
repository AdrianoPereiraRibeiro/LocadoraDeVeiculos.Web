using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxaEServico
{
    public class TaxaEServico : EntidadeBase
    {
        public string Nome { get; set; }
        public FIxoOuDiario FixoOuDiario  { get; set; }
        public decimal Preco { get; set; }
        public override List<string> Validar()
        {
            List<string> erros = [];

            if (Nome.Length <= 3)
                erros.Add("O nome é obrigatório e deve possuir mais de 3 caracteres!");
            if(FixoOuDiario.Equals(null))
            erros.Add("A escolha de taxa ou serviço é obrigatória!");
            if (Preco<=0)
                erros.Add("O preço deve ser maior do que 0!");
            return erros;
        }
    }
}
