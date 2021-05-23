using System;
using System.Collections;
using System.Linq;
using ConsoleTables;

namespace sistema_de_operacoes
{
    public class Program
    {
        public static double operacoesTotal1 = 0;
        public static double taxaTotal1 = 0;
        public static ArrayList objetos = new ArrayList();
        public static int w = 0;
        static void Main(string[] args)
        {
            int i;
            
            string moedaDestino, nome, moedaOrigem, moedaOrigem1;
            double resultado, quantidade, taxaDeCambio;
            double taxaTotal = 0 , operacoesTotal = 0 , taxaPadrao;
            string Data;
            int contas = 0;


            //ENTRADA DE DADOS 

            do
            {
                String opcaoUsuario = OpcaoUsuario();
                Console.WriteLine("Informe o seu nome para cadastro:");
                nome = Console.ReadLine();
                if (string.IsNullOrEmpty(nome)) // Persistencia de dados, caso dado seja invalido
                {
                    Console.WriteLine("O nome nao pode ser vazio! Digite novamente:");
                    nome = Console.ReadLine();
                }
                Console.WriteLine("Insira o dia de hoje: (nesse formato(dia/mes/ano) ex: 14/06/2021)");
                Data = Console.ReadLine();
                if (string.IsNullOrEmpty(Data)) // Persistencia de dados, caso dado seja invalido
                {
                    Console.WriteLine("A data nao pode ser vazia! Digite novamente:");
                    Data = Console.ReadLine();
                }
                Console.WriteLine("Digite o numero da moeda de origem que deseja converter:");
                moedaOrigem = Console.ReadLine();
                int moedaOri;
                if (int.TryParse(moedaOrigem, out moedaOri)) { } // Persistencia de dados, caso dado seja invalido
                else
                    Console.WriteLine("Coloque um dos numeros de 1-4");
                if(moedaOri != 1 && moedaOri != 2 && moedaOri != 3 && moedaOri != 4) // Persistencia de dados, caso dado seja invalido
                {
                    Console.WriteLine("Coloque um dos numeros de 1-4");
                    moedaOrigem = Console.ReadLine();
                    int.TryParse(moedaOrigem, out moedaOri);
                }
                moedaOrigem1 = "";
                switch (moedaOri) // switch para printar a opcao da moeda na tabela
                {
                    case 1:
                        moedaOrigem1 = "Dolar";
                        break;
                    case 2:
                        moedaOrigem1 = "Real";
                        break;
                    case 3:
                        moedaOrigem1 = "Euro";
                        break;
                    case 4:
                        moedaOrigem1 = "Libra";
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Insira quanto voce quer converter: ");
                quantidade = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Digite o numero pra qual moeda de destino deseja converter");
                String opcao = Console.ReadLine();
                int moedaFim;
                if (int.TryParse(opcao, out moedaFim)) { } // Persistencia de dados, caso dado seja invalido
                else
                    Console.WriteLine("Coloque um dos numeros de 1-4");
                if (moedaFim != 1 && moedaFim != 2 && moedaFim != 3 && moedaFim != 4) // Persistencia de dados, caso dado seja invalido
                {
                    Console.WriteLine("Coloque um dos numeros de 1-4");
                    opcao = Console.ReadLine();
                    int.TryParse(opcao, out moedaFim);
                }

                moedaDestino = "";
                
                switch (moedaFim) // switch para printar a opcao da moeda na tabela
                {
                    case 1:
                        moedaDestino = "Dolar";
                        break;
                    case 2:
                        moedaDestino = "Real";
                        break;
                    case 3:
                        moedaDestino = "Euro";
                        break;
                    case 4:
                        moedaDestino = "Libra";
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Insira a taxa da cambio:(quanto esta a relacao entre a moeda origem para a destino)"); // cambio da moeda
                Console.WriteLine("ex: (R$: 1.00 custa $: 0.19, entao caso queira converter de real para dolar coloque 0.19)");
                taxaDeCambio = Convert.ToSingle(Console.ReadLine());
                taxaPadrao = (0.10 * (quantidade * taxaDeCambio));
                string t = taxaPadrao.ToString("N2"); // fixar em apenas 2 casas decimais os resultados
                taxaTotal += taxaPadrao;
                operacoesTotal += quantidade;
                string o = operacoesTotal.ToString("N2");
                resultado = (quantidade * taxaDeCambio) - taxaPadrao;
                string r = resultado.ToString("N2");

                contas++;
                operacoesTotal1 = operacoesTotal; 
                taxaTotal1 = taxaTotal;
                objetos.Add(nome);          //add os dados do usario na array para colocar na tabela
                objetos.Add(moedaOrigem1);
                objetos.Add(moedaDestino);
                objetos.Add(Data);
                objetos.Add(quantidade);
                objetos.Add(r);
                objetos.Add(t);

                w++;
                Console.WriteLine("Voce gostaria de cadastrar mais uma operacao: (s/n)"); // Continuar loop de cadastro ou nao
                String x = Console.ReadLine();
                i = string.Compare(x, "n");
            } while (i != 0);
            //-------------------------------------------------------------------------------------------------------------------------------//

            string opcaoUsuario1 = OpcaoUsuario1();
            
                switch (opcaoUsuario1) // menu do sistema
                {
                    case "1": // tabela criada com nuget
                    var table = new ConsoleTable("Entrada", "Nome do cliente" ,"Moeda Origem"  , "Moeda Destino"  , "Data" , "Valor Original"  , "Valor Convertido", "taxa");
                    
                    for (int h = 1; h < objetos.Count;h++) //array dos dados do usuario para colocar na tabela
                    {
                        table.AddRow(objetos[h--], objetos[h++], objetos[h++], objetos[h++], objetos[h++], objetos[h++], objetos[h++], objetos[h++]);
                    }
                           
                    
                        table.Write();
                        Console.WriteLine();
                        break;
                    case "2": // valor das operacoes
                        Console.WriteLine("O valor total de todas as operacoes resulta em:  " + operacoesTotal1);
                        break;
                    case "3": // valor das taxas
                        Console.WriteLine("O valor de todas as taxas cobradas resulta em:  " + taxaTotal1);
                        break;
                    default:
                        Console.WriteLine("Informe um dos numeros do menu");
                        break;
                }
            




        }

        private static string OpcaoUsuario() // menu de opcoes de moeda
        {
            Console.WriteLine("ESSAS SAO AS MOEDAS QUE VOCE PODE TROCAR, APERTE (ENTER) PARA COMECAR");
            Console.WriteLine();
            Console.WriteLine("1- ($) DOLAR ");
            Console.WriteLine("2- (R$) REAL ");
            Console.WriteLine("3- (€) EURO ");
            Console.WriteLine("4- (£) LIBRA ");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
        private static string OpcaoUsuario1() // menu do sistema com as opcoes de acoes
        {
            Console.WriteLine("---SISTEMA DE OPERACOES---");
            Console.WriteLine();
            Console.WriteLine("1- Historico de operacoes");
            Console.WriteLine("2- Valor total de operacoes");
            Console.WriteLine("3- Valor total das taxas cobradas");
            Console.WriteLine("X- Sair");

            string opcaoUsuario1 = Console.ReadLine();
            return opcaoUsuario1;
        }
    }
}