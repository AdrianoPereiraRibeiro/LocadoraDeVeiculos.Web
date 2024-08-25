using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase
    {
        public Cliente Cliente {get; set; }
        public int ClienteId {get; set; }

        public bool ClienteEqualsCondutor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public DateTime Validade { get; set; }
        
        public override List<string> Validar()
        {
            List<string> erros = [];

            if (Cliente.Equals(null))
                erros.Add("O cliente é obrigatório!");

            if (Nome.Length <= 3)
                erros.Add("O nome é obrigatório e deve possuir mais de 3 caracteres!");

            if (string.IsNullOrEmpty(Email))
                erros.Add("O email é obrigatório!");

            if (string.IsNullOrEmpty(Telefone))
                erros.Add("O telefone é obrigatório!");

            if (string.IsNullOrEmpty(CPF))
                erros.Add("O CPF é obrigatório!");

            if (string.IsNullOrEmpty(CNH))
                erros.Add("O CNH é obrigatório!");

            if (Validade<DateTime.Now)
                erros.Add("A data de validade é inválida!");

            return erros;
        }
    }
}
