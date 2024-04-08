using Banco.Model.Services;
using Exercicio01.Model.entities;
using Exercicio01.Model.Services;
using Exercicio01.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Views
    {
    internal class ViewContaBancaria
        {
        public static void OperacoesBancarias ( )
            {
            ServiceContaBancaria service = new ServiceContaBancaria ();
            ServicesCliente servicesCliente = new ServicesCliente ();

            int operacao = 1;
            do {
                Console.Clear ();
                if (operacao < 1 || operacao > 5)
                    Console.WriteLine ("Operacao invalida, digite novamente");
                Console.WriteLine ("-------- Conta Bancaria ---------");
                Console.WriteLine ("1) Cadastrar.");
                Console.WriteLine ("2) Listar.");
                Console.WriteLine ("3) Procurar conta.");
                Console.WriteLine ("4) Remover conta.");
                Console.WriteLine ("5) Voltar.");
                operacao = Leitura.LerIntComMsg ("\nDigite a operacao: ");
                switch (operacao) {
                    case 1:
                        CadastrarConta (service, servicesCliente);
                        break;
                    case 2:
                        ListarContas (service);
                        break;
                    case 3:
                        ProcurarConta (service);
                        break;
                    case 4:
                        RemoverConta (service);
                        break;
                    }
                } while (operacao != 5);
            }

        private static void ProcurarConta ( ServiceContaBancaria service )
            {
            long numeroConta = Leitura.LerLongComMsg ("Numero da conta do CLiente: ");
            ContaBancaria? conta = service.FindById (numeroConta);

            if (conta == null) {
                Console.WriteLine ("Conta nao cadastrada.");
                }
            else {
                Console.Clear ();
                Console.WriteLine ("------------Conta---------- ");
                Console.WriteLine (conta);

                int flag = Leitura.LerFlagComMsg ("Voce quer realizer alguma operacao");
                if ( flag == 1) {
                    ViewOperacaoBancaria.ViewOperacoes (conta);
                    }

                }
                Console.WriteLine ("\nPrecione Enter para continuar.");
                Console.ReadKey ();
            }

        private static void RemoverConta ( ServiceContaBancaria service )
            {
            Console.Clear ();
            long operador;
            long id = Leitura.LerLongComMsg ("Numero da conta do CLiente que voce deseja excluir: ");
            ContaBancaria? conta = service.FindById (id);

            if (conta == null)
                Console.WriteLine ("Esta Conta nao esta cadastrada.");
            else if (conta.GetTransacaos ().Count != 0) {
                Console.WriteLine ("nao é possivel remover este cliente, pois ele possui Transacoes registradas em seu nome.");
                }
            else {
                Console.WriteLine (conta);

                do {
                    operador = Leitura.LerIntComMsg ("Tem certeza que deseja excluir este conta (1: sim) (2: nao):");
                    if (operador != 1 && operador != 2) {
                        Console.WriteLine ("Digite 1 ou 2.");
                        }
                    } while (operador != 1 && operador != 2);

                if (operador == 1) {
                    service.Remove (conta);

                    Console.WriteLine ("Conta removido com sucesso.");
                    }
                else {
                    Console.WriteLine ("Operacao finalizada.");
                    }
                }

            Console.WriteLine ("\nPrecione Enter para continuar.");
            Console.ReadKey ();
            }

        private static void ListarContas ( ServiceContaBancaria service )
            {
            Console.Clear ();
            List<ContaBancaria> contas = service.FindAll ();
            Console.WriteLine ("Lista de Contas Bancarias: ");
            long index = 1;
            if (contas.Count == 0)
                Console.WriteLine ("Nenhum Conta cadastrado.");
            foreach (ContaBancaria conta in contas) {
                Console.WriteLine ($"\nCliente {index++}: ");
                Console.WriteLine (conta);
                }
            Console.WriteLine ("\nPrecione Enter para continuar.");
            Console.ReadKey ();
            }

        private static void CadastrarConta ( ServiceContaBancaria service, ServicesCliente servicesCliente )
            {
            long cpf = Leitura.LerLongComMsg ("Qual o cpf do cliente: ");
            Cliente? cliente = servicesCliente.FindById (cpf);
            if (cliente == null)
                Console.WriteLine ("Cliente nao encontrado.");
            else if (cliente.Conta != null) {
                Console.WriteLine ("Cliente ja possui conta bancaria.");
                }
            else {
                long numeroConta = 0;
                long operador;
                Console.WriteLine ("Cliente: ");
                Console.WriteLine (cliente);
                do {
                    operador = Leitura.LerIntComMsg ("Voce deseja criar uma conta bancaria para este cliente (1: sim) (2: nao): ");
                    if (operador != 1 && operador != 2) {
                        Console.WriteLine ("Digite 1 ou 2.");
                        }
                    } while (operador != 1 && operador != 2);
                if (operador == 1) {
                    do {
                        numeroConta = new Random ().Next (1000000, 9999999);
                        } while (service.FindById (numeroConta) != null);

                    ContaBancaria conta = new ContaBancaria (numeroConta, cliente);
                    service.Create (conta);
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
