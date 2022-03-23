using Folha.Helpers;
using Xunit;

namespace Teste
{
    public class CpfHelperTeste
    {
        [Fact]
        public void DeveRetornarTrueAoValidarCpf()
        {
            //arrange
            var cpf = "15264265011";

            //action
           var resultado = CpfHelper.Validar(cpf);

            //assert
            Assert.True(resultado);
        }

        [Fact]
        public void DeveRetornarFalseAoValidarCpf()
        {
            //arrange
            var cpf = "05264265011";

            //action
            var resultado = CpfHelper.Validar(cpf);

            //assert
            Assert.False(resultado);
        }
    }
}