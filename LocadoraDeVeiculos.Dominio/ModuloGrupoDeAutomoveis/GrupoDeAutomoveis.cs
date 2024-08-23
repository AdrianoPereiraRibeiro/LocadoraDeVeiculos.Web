using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeAutomoveis
{
    public class GrupoDeAutomoveis : EntidadeBase
    {
        public string Nome { get; set; }
        public List<Veiculo> Veiculos { get; set; } = [];
        public override List<string> Validar()
        {
            List<string> erros = [];

            if (Nome.Length<=3)
                erros.Add("O nome é obrigatório e deve possuir mais de 3 caracteres!");
            return erros;
        }
    }
}
