using System.ComponentModel.DataAnnotations;

namespace Folha.Models
{

    public class Funcionario : Pessoa
    {
        protected Funcionario()
        {

        }

        public Funcionario(
            string setor,
            double salarioBruto,
            DateTime dataDeAdmissao,
            bool descontoNoPlanoDeSaude,
            bool descontoNoPlanoDental,
            bool descontoNoValeTransporte,
            string nome, string sobrenome, string documento) : base( nome,  sobrenome,  documento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
            Setor = setor;
            SalarioBruto = salarioBruto;
            DataDeAdmissao = dataDeAdmissao;
            DescontoNoPlanoDeSaude = descontoNoPlanoDeSaude;
            DescontoNoPlanoDental = descontoNoPlanoDental;
            DescontoNoValeTransporte = descontoNoValeTransporte;
        }
        public string Setor { get; private set; }
        public double SalarioBruto { get; private set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public DateTime DataDeAdmissao { get; private set; }
        public bool DescontoNoPlanoDeSaude { get; private set; }
        public bool DescontoNoPlanoDental { get; private set; }
        public bool DescontoNoValeTransporte { get; private set; }

        public double Desconto(double valorDesconto)
        {

            return SalarioBruto - valorDesconto;
        }

        public void AlterarSalario(double salarioBruto)
        {
            if (salarioBruto > 0)
            {

                SalarioBruto = salarioBruto;
            }
        }

    }
}
