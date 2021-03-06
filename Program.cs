﻿using System;
using System.IO;

namespace AtividadeAvaliativa
{
    class Program
    {
        static Funcionario[] vetor = new Funcionario[10];



        static void Main(string[] args)
        {
            String linha = " ";
            int contador = 0, opcao;

            lerArquivo(ref contador, linha, vetor);
            do
            {

                Menu();
                opcao = Convert.ToInt16(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Incluir(ref contador);
                        break;
                    case 2:
                        CalculoSalario();
                        Console.ReadKey();
                        break;
                    case 3:
                        Relacao();
                        break;
                    case 4:
                        //Para sair do programa
                        break;
                    default:
                        Console.WriteLine("OPÇÃO INVÁLIDA");
                        Console.ReadKey();
                        break;
                }
            } while (opcao == 1 || opcao == 2 || opcao == 3 && opcao != 4);




        }
        static void lerArquivo(ref int contador, string linha, Funcionario[] vetor)
        {
            string[] auxSeparador = new String[7];      //para separar os dados de cada linha

            StreamReader arquivo = new StreamReader("testedaprova.txt"); //FICA ESPERTO COM O ENDEREÇO
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  BANCO DE DADOS DE FUNCIONÁRIOS CADASTRADOS                    ║");

            //abrir o arquivo para leitura
            while ((linha = arquivo.ReadLine()) != null)
            {
                //Enquanto a linha que está recendo as linhas do arquivo e for diferente de null
                auxSeparador = linha.Split(';');    //separa os dados

                //ONDE OCORRE A DIVISÃO DAS PESSOAS ANTES DE VIRAR OBJETO ADMINISTRATIVO OU PROFESSOR
                if (int.Parse(auxSeparador[0]) == 1)
                {
                    vetor[contador] = new Administrativos(int.Parse(auxSeparador[0]), int.Parse(auxSeparador[1]), auxSeparador[2], auxSeparador[3], double.Parse(auxSeparador[4]), auxSeparador[5], double.Parse(auxSeparador[6]));
                }

                else
                {
                    vetor[contador] = new Professores(int.Parse(auxSeparador[0]), int.Parse(auxSeparador[1]), auxSeparador[2], auxSeparador[3], double.Parse(auxSeparador[4]), auxSeparador[5], double.Parse(auxSeparador[6]));
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("  " + linha);
                Console.WriteLine("CÓDIGO DE SEGURANÇA PARA BUSCA: " + (contador));
                contador++;
            }
            arquivo.Close();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
            Console.ReadKey();


            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("║                CALCULO DE SALÁRIO LIQUIDO                    ║");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("║DIGITE 1 -   CADASTRO DE FUNCIONÁRIO                          ║");
            Console.WriteLine("║DIGITE 2 -   CALCULO DE FUNCIONÁRIO                           ║");
            Console.WriteLine("║DIGITE 3-    DADOS DOS FUNCIONÁRIOS                           ║");
            Console.WriteLine("║DIGITE 4 -   SAIR                                             ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
        }

        static void CalculoSalario()
        {
            int codigo;


            Console.WriteLine("Digite o código do contribuinte: ");
            codigo = Convert.ToInt16(Console.ReadLine());

            for (int i = 0; i < vetor.Length; i++)
            {
                if (i == codigo)
                {
                    Console.Write("O resultado da salario liquido do contribuinte selecionado é: ");
                    Console.WriteLine(vetor[i].CalculoSalarioBruto());
                }
            }
        }

        static void Incluir(ref int contador)
        {
            int numeroMatrica, cargo;
            double salarioBase, horaExtra;
            string nome, endereco, cpf;

            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("║                    CADASTRO DE CONTRIBUINTE                  ║");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");

            Console.Write("Digite seu nome: ");
            nome = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(nome + " digite o código do cargo: ");
            Console.WriteLine();
            Console.WriteLine("Para ADMINISTRATIVO:            Digite 1 ");
            Console.WriteLine("Para PROFESSOR :                Digite 2");
            Console.WriteLine("Para PROFESSOR MESTRE :         Digite 3");
            Console.WriteLine("Para PROFESSOR DOUTOR :         Digite 4");
            cargo = Convert.ToInt16(Console.ReadLine());
            Console.Write("Digite o número da sua matrícula: ");
            numeroMatrica = Convert.ToInt32(Console.ReadLine());
            Console.Write(nome + " digite seu endereço: ");
            endereco = Console.ReadLine();
            if (cargo == 1)
            {
                Console.Write("Digite seu sálario base: ");
                salarioBase = Convert.ToDouble(Console.ReadLine());
            }
            else
            {
                Console.Write("Digite a quantidade de aulas que é lecionada: ");
                salarioBase = Convert.ToDouble(Console.ReadLine());
            }
            Console.Write("Digite seu cpf: ");
            cpf = Console.ReadLine();
            if (cargo == 1)
            {
                Console.Write("Digite as horas extras caso houver: ");
                horaExtra = Convert.ToDouble(Console.ReadLine());
            }
            else
            {
                Console.Write("Digite a quantidade de aulas extras que foram lecionadas: ");
                horaExtra = Convert.ToDouble(Console.ReadLine());
            }

            //MOMENTO QUE ESTÁ SENDO SALVO A INCLUSÃO DOS CADASTRADOS COMO OBJETO DENTRO DO VETOR

            if (cargo == 1)
            {
                vetor[contador] = new Administrativos(cargo, numeroMatrica, nome, endereco, salarioBase, cpf, horaExtra);
            }
            else
            {
                vetor[contador] = new Professores(cargo, numeroMatrica, nome, endereco, salarioBase, cpf, horaExtra);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            //CODIGO USADO PARA SABER O FUNCIONARIO QUE IRÁ TER O SALARIO CALCULADO
            Console.WriteLine("Seu código de segurança é: " + contador);
            contador++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Dados salvo com sucesso..");
            Console.ReadKey();
        }

        static void Relacao()
        {
            for (int i = 0; i < vetor.Length; i++)
            {
                try
                {
                    Console.WriteLine(vetor[i].RelacaoDados());
                }
                catch
                {
                    Console.Write("");

                }

            }
            Console.ReadKey();
        }
    }
}