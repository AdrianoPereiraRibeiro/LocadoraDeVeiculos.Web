using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string? CPF { get; set; }
        public string? CNPJ { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }


        protected Cliente()
        {
        }

        public Cliente(
            string nome,
            string email,
            string telefone,
            TipoPessoa tipoPessoa,
            string cpf,
            string cnpj,
            string estado,
            string cidade,
            string bairro,
            string rua,
            string numero
        )
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            TipoPessoa = tipoPessoa;
            CPF = cpf;
            CNPJ = cnpj;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;

        }

        public override List<string> Validar()
        {
            List<string> erros = [];

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O nome é obrigatório");

            if (string.IsNullOrEmpty(Email))
                erros.Add("O email é obrigatória");

            if (string.IsNullOrEmpty(Telefone) || Telefone.Length > 15)
                erros.Add("O telefone é obrigatório");

            if (TipoPessoa.Equals(null))
                erros.Add("O tipo de pessoa é obrigatório");

            if (string.IsNullOrEmpty(CPF) || CPF.Length > 15)
                erros.Add("O CPF é obrigatório");

            if (string.IsNullOrEmpty(CNPJ) || CNPJ.Length > 20)
                erros.Add("O CNPJ é obrigatório");

            if (string.IsNullOrEmpty(Estado))
                erros.Add("O estado é obrigatório");

            if (string.IsNullOrEmpty(Cidade))
                erros.Add("A cidade é obrigatória");

            if (string.IsNullOrEmpty(Bairro))
                erros.Add("O bairro é obrigatório");

            if (string.IsNullOrEmpty(Rua))
                erros.Add("A rua é obrigatória");

            if (string.IsNullOrEmpty(Numero))
                erros.Add("O número é obrigatória");
            return erros;
        }
    }
}