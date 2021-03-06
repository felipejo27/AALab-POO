﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeAvaliativa
{
    class Administrativos : Funcionario
    {

        public Administrativos(int c, int m, string n, string e, double s, string cp, double h)
        {
            Cargo = c;
            Matricula = m;
            Nome = n;
            Endereco = e;
            SalarioBase = s;
            Cpf = cp;
            HoraExtra = h;

        }


        public override double CalculoSalarioBruto()
        {
            SalarioBruto = SalarioBase + (HoraExtra * (SalarioBase / 100));

            //INSS sendo debitado
            SalarioLiquido = SalarioBruto - (SalarioBruto * 0.11);

            //imposto de renda é de 10% se o salario for maior que 1000 reais 
            if (SalarioBruto > 1000)
            {
                //Deduções do INSS
                if (SalarioBase > 30000)
                {
                    SalarioLiquido = SalarioBruto - 3000;
                }
                else
                {
                    SalarioLiquido = SalarioBruto - (SalarioBase * 0.11);
                }

                //Deduções do IPRF
                if (SalarioLiquido > 4000)
                {
                    SalarioLiquido = SalarioLiquido - (SalarioLiquido * 0.25);
                }
                // inss é de 5% com desconto até 400 reais 
                return SalarioLiquido;
            }
            else
            {
                return SalarioBruto;
            }


        }

    }
}