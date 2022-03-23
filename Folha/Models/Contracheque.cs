using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using Folha.Models.Factories;

namespace Folha.Models
{
    [NotMapped]
    public class Contracheque
    {
        public Contracheque(double totalDeDescontos, double salarioLiquido , Funcionario funcionario)
        {
            TotalDeDescontos = totalDeDescontos;
            SalarioLiquido = salarioLiquido;
            Funcionario = funcionario;
        }
        public string MesDeReferencia = DateTime.Now.ToString("M");

        [DataType(DataType.Currency)]
        public double TotalDeDescontos { get; set; }

        [DataType(DataType.Currency)]
        public double SalarioLiquido { get; set; }

        public Funcionario Funcionario { get; set; }

    }
}
