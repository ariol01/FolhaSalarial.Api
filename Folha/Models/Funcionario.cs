using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Folha.Models
{

    [Index(nameof(Documento), IsUnique = true)]
    public class Funcionario : Pessoa
    {
        protected Funcionario()
        {

        }
        public Funcionario(string setor, double salarioBruto, DateTime dataDeAdmissao, bool descontoNoPlanoDeSaude, bool descontoNoPlanoDental, bool descontoNoValeTransporte)
        {
            Setor = setor;
            SalarioBruto = salarioBruto;
            DataDeAdmissao = dataDeAdmissao;
            DescontoNoPlanoDeSaude = descontoNoPlanoDeSaude;
            DescontoNoPlanoDental = descontoNoPlanoDental;
            DescontoNoValeTransporte = descontoNoValeTransporte;
        }
        public string Setor { get; private set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Informe o campo salario bruto. e obrigatório")]
        [Range(1, Double.MaxValue, ErrorMessage = "O campo {0} deve ser maior que {1}.")]
        public double SalarioBruto { get; private set; }

        [Required(ErrorMessage = "Informe o campo data de admissão. e obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public DateTime DataDeAdmissao { get; private set; }
        public bool DescontoNoPlanoDeSaude { get; private set; }
        public bool DescontoNoPlanoDental { get; private set; }
        public bool DescontoNoValeTransporte { get; private set; }

        public double Desconto(double valorDesconto)
        {

            return SalarioBruto - valorDesconto;
        }

        public Funcionario MontarFuncionario(Funcionario funcionario)
        {
            return new Funcionario
            {
                Nome = funcionario.Nome,
                Sobrenome = funcionario.Sobrenome,
                Documento = funcionario.Documento,
                SalarioBruto = funcionario.SalarioBruto,
                Setor = funcionario.Setor,
                DataDeAdmissao = funcionario.FormatarDataParaPadraoBrasileiro(funcionario.DataDeAdmissao),
                DescontoNoPlanoDental = funcionario.DescontoNoPlanoDental,
                DescontoNoPlanoDeSaude = funcionario.DescontoNoPlanoDeSaude,
                DescontoNoValeTransporte = funcionario.DescontoNoValeTransporte,
                Id = funcionario.Id,
            };
        }
        public DateTime FormatarDataParaPadraoBrasileiro(DateTime data)
        {
            var dataFormatada = data.ToShortDateString();
            DataDeAdmissao = Convert.ToDateTime(dataFormatada);
            return DataDeAdmissao;
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
