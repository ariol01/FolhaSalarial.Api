using System.ComponentModel.DataAnnotations;

namespace Folha.Models.Dtos
{
    public class FuncionarioDto
    {
        [StringLength(200)]
        [Required(ErrorMessage = "Informe o campo nome. é obrigatório")]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Sobrenome { get; set; }

        [StringLength(11, ErrorMessage = ("O campo CPF deve ter 11 digitios. tente novamente."))]
        [Required(ErrorMessage = "Informe o campo CPF. é obrigatório")]
        public string Documento { get; set; }
        public string Setor { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Informe o campo salario bruto. e obrigatório")]
        [Range(1, Double.MaxValue, ErrorMessage = "O campo {0} deve ser maior que {1}.")]
        public double SalarioBruto { get; set; }

        [Required(ErrorMessage = "Informe o campo data de admissão. e obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public DateTime DataDeAdmissao { get; set; }
        public bool DescontoNoPlanoDeSaude { get; set; }
        public bool DescontoNoPlanoDental { get; set; }
        public bool DescontoNoValeTransporte { get; set; }
    }
}
