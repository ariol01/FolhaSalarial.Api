using Folha.Controllers;
using Folha.Interfaces;
using Folha.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Teste
{
    public class FuncionarioTeste
    {
        [Fact]
        public async Task DeveCriarFuncionario()
        {
            var funcionarioDto = new FuncionarioDto
            {
                Setor = "Teste",
                SalarioBruto = 4000,
                DataDeAdmissao = DateTime.Now,
                DescontoNoPlanoDeSaude = true,
                DescontoNoPlanoDental = true,
                DescontoNoValeTransporte = true,
                Nome = "jorge",
                Sobrenome = "teste",
                Documento = "76036645007"
            };

            var repo = new Mock<IFuncionarioRepositorio>();
            var http = new Mock<IHttpContextAccessor>();

            http.Setup(x => x.HttpContext).Returns(new DefaultHttpContext());

            var controller = new FuncionarioController(repo.Object, http.Object);
            await controller.Post(funcionarioDto);

        }
    }
}
