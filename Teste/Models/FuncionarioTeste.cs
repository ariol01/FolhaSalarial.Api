using Folha.Models;
using Moq;
using Xunit;

namespace Teste.Models
{
    public class FuncionarioTeste
    {
        [Fact]
        public void DeveCriarFuncionario()
        {
            var funcionario = new Mock<Funcionario>();
            funcionario.Object.Id = 1;
            funcionario.Object.Nome = "teste";
            funcionario.Object.Sobrenome = "teste 2";
            funcionario.Object.Documento = "02005350052";
            
            Assert.NotNull(funcionario.Object);
            Assert.Equal(1, funcionario.Object.Id);
        }

        [Fact]
        public void NaoDeveCriarFuncionario()
        {
            var funcionario = new Mock<Funcionario>();
            funcionario.Object.Id = 0;
            funcionario.Object.Nome = "teste";
            funcionario.Object.Sobrenome = "teste 2";
            funcionario.Object.Documento = "02005350052";
           
            Assert.Equal(0, funcionario.Object.Id);
        }
    }
}
