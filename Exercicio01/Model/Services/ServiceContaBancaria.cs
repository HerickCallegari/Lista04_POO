using Exercicio01.Model.entities;
using Exercicio01.Model.Services;
using Exercicio01.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Model.Services
    {
    internal class ServiceContaBancaria
        {
        //Simular conexao com banco
        public static List<ContaBancaria> contas = new List<ContaBancaria> ();

        ServicesCliente service = new ServicesCliente ();
        public void CriarConta ( )
            {
            int cpf = Leitura.LerIntComMsg ("Qual o cpf do cliente: ");
            Cliente? cliente = service.ProcurarCliente (cpf);
            if (cliente == null)
                Console.WriteLine ("Cliente nao encontrado.");
            else if (cliente.Conta != null) {
                Console.WriteLine ("Cliente ja possui conta bancaria.");
                }
            else {
                int numeroConta = 0;
                int operador;
                Console.WriteLine ("Cliente: ");
                Console.WriteLine (cliente);
                do {
                    operador = Leitura.LerIntComMsg ("Voce deseja criar uma conta bancaria para este cliente (1: sim) (2: nao): ");
                    if (operador != 1 && operador != 2) {
                        Console.WriteLine ("Digite 1 ou 2.");
                        }
                    } while (operador != 1 && operador != 2);
                if (operador == 1) {
                    ContaBancaria conta = new ContaBancaria (numeroConta, cliente);
                    Console.WriteLine ("Conta criada com sucesso.");
                    }
                else
                    Console.WriteLine ("Operacao cancelada.");
                }
            Console.WriteLine ("\nPrecione Enter para continuar.");
            Console.ReadKey ();
            }
        }
    }
