using Biblioteca;
using Exercicio01.Model.entities;
using Exercicio01.Model.Utils;
using Exercicio01.Views;

/* 
 * Esta aplicacao tem objetivo de reforçar o 
 * conceito de encapsulamento de campos, o 
 * professor não permitiu a utilização de 
 * tecnologias e recusos mais avançados dos que
 * foram utilizados para esta aplicação 
 */
namespace Exercicio01
    {
    internal class Program
        {
        

        static void Main ( string[] args )
            {
            ViewCliente.clientes.Add (new Cliente ("teste", 1234, "teste@gmail.com", "teste", "4599123123"));
            int operacao = 1;
            //estrutura de direcionamento de codigo
            do {
                Console.Clear ();
                if (operacao < 1 || operacao > 4)
                    Console.WriteLine ("Operacao invalida, digite novamente");
                Console.WriteLine ("-------- Operacoes ---------");
                Console.WriteLine ("1) Cliente.");
                Console.WriteLine ("2) Conta Bancaria");
                Console.WriteLine ("3) encerrar.");
                operacao = Leitura.LerIntComMsg ("\nDigite a operacao: ");
                switch (operacao) {
                    case 1:
                        ViewCliente.OperacoesCliente ();
                        break;
                    case 2:

                        break;
                    case 3:
                        break;
                    }
                } while (operacao != 3);
            }
        }
    }
