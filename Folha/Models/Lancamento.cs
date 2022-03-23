using Folha.Constantes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Folha.Models
{
    [NotMapped]
    public static class Lancamento
    {
        public static double CalcularAuxilios(Funcionario funcionario)
        {
            var totalDeDescontos = 0.0;
            if (funcionario.DescontoNoPlanoDental)
            {
                totalDeDescontos += Auxilios.PlanoDental;
            }
            if (funcionario.DescontoNoPlanoDeSaude)
            {
                totalDeDescontos += Auxilios.PlanoSaude;
            }
            if (funcionario.DescontoNoValeTransporte)
            {
                totalDeDescontos += CalcularValeTransporte(funcionario.SalarioBruto);
            }
            return totalDeDescontos;
        }

        public static double CalcularSalarioLiquido(Funcionario funcionario, double descontos)
        {
            var liquido = funcionario.Desconto(Convert.ToDouble(descontos));

            return liquido;
        }

        public static double CalcularTotalDeDescontos(Funcionario funcionario)
        {
            var total = 0.0;
            var fgts = DescontarFGTS(funcionario.SalarioBruto);
            var inss = DescontarINSS(funcionario.SalarioBruto);
            var irpf = DescontarIRPF(funcionario.SalarioBruto);
            var auxilios = CalcularAuxilios(funcionario);
            total = (fgts + inss + irpf + auxilios);


            return Convert.ToDouble(total);
        }
        public static double DescontarFGTS(double salario)
        {
            var total = "";

            total = (salario * Descontos.OitoPorcentoFGTS).ToString("N2");

            return Convert.ToDouble(total);

        }
        public static double DescontarINSS(double salarioBruto)
        {
            var total = 0.0;
            //fonte tirada da internet inss de 2022.
            if (salarioBruto <= 1212)
            {
                total += salarioBruto * Descontos.SeteEMeioPorcentoINSS;
                return total;
            }

            if (salarioBruto >= 1212.01 && salarioBruto <= 2427.35)
            {
                total += salarioBruto * Descontos.NovePorcentoINSS;
                return total;
            }
            if (salarioBruto >= 2427.36 && salarioBruto <= 3641.03)
            {
                total += salarioBruto * Descontos.DozePorcentoINSS;
                return total;
            }
            if (salarioBruto >= 3641.04 && salarioBruto <= 7087.22)
            {
                total += salarioBruto * Descontos.QuartozePorcentoINSS;
                return total;
            }
            return total;
        }

        public static double DescontarIRPF(double salario)
        {
            var total = 0.0;

            if (salario >= 1903.99 && salario <= 2826.65)
            {
                total = Descontos.SeteEMeioPorcentoIRPF;
                return total;
            }
            if (salario >= 2826.66 && salario <= 3751.05)
            {
                total = Descontos.QuinzePorcentoIRPF;
                return total;
            }

            if (salario >= 3751.06 && salario <= 4.66468)
            {
                total = Descontos.VinteDoisEMeioPorcentoIRPF;
                return total;
            }

            if (salario >= 4664.68)
            {
                total = Descontos.VinteSeteEMeioPorcentoIRPF;
                return total;
            }

            return total;

        }

        public static double CalcularValeTransporte(double salario)
        {
            var total = 0.0;
            if (salario >= 1500)
            {
                total = (salario * Auxilios.ValeTransporte);
            }
            return total;
        }

    }

}

