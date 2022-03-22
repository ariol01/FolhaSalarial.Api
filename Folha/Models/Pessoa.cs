using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Folha.Models
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "Informe o campo nome. é obrigatório")]
        public string Nome { get; set; }
        
        [StringLength(100)]
        public string Sobrenome { get; set; }

        [StringLength(11, ErrorMessage = ("O campo CPF deve ter 11 digitios. tente novamente."))]
        [Required(ErrorMessage = "Informe o campo CPF. é obrigatório")]
        public string Documento { get; set; }

    }
}
