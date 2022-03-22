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
            funcionario.Setup(x=>x.Id).Returns(1);

            Assert.Equal(1, funcionario.Object.Id);
        }

        [Fact]
        public void NaoDeveCriarFuncionario()
        {
            var funcionario = new Mock<Funcionario>();
            funcionario.Setup(x => x.Id).Returns(0);

            Assert.Equal(0, funcionario.Object.Id);
        }
    }
}
