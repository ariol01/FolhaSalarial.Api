using Folha.Models.Dtos;

namespace Folha.Models.Factories
{
    public static class FuncionarioFactory
    {
        public static Funcionario Criar(FuncionarioDto funcionarioDto)
        {
            return new Funcionario(
                funcionarioDto.Setor,
                funcionarioDto.SalarioBruto,
                funcionarioDto.DataDeAdmissao,
                funcionarioDto.DescontoNoPlanoDeSaude,
                funcionarioDto.DescontoNoPlanoDental,
                funcionarioDto.DescontoNoValeTransporte,
                funcionarioDto.Nome,
                funcionarioDto.Sobrenome,
                funcionarioDto.Documento);
        }
    }
}
