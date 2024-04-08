using Banco.Model.Services;
using Exercicio01.Model.entities;
using Exercicio01.Model.Entities.associative;
using Exercicio01.Model.Utils;

namespace Banco.Views
    {
    internal class ViewOperacaoBancaria
        {
        public static void ViewOperacoes ( ContaBancaria conta )
            {
            ServiceOperacaoBancaria service = new ServiceOperacaoBancaria (conta);
            ServiceContaBancaria serviceContaBancaria = new ServiceContaBancaria ();
            int operacao = 1;
            do {
                Console.Clear ();
                Console.WriteLine(conta + "\n");
                if (operacao < 1 || operacao > 5)
                    Console.WriteLine ("Operacao invalida, digite novamente");
                Console.WriteLine ("-------- Cliente ---------");
                Console.WriteLine ("1) Depositar.");
                Console.WriteLine ("2) Sacar.");
                Console.WriteLine ("3) Transferir.");
                Console.WriteLine ("4) Lista de Transacoes.");
                Console.WriteLine ("5) Voltar.");
                operacao = Leitura.LerIntComMsg ("\nDigite a operacao: ");
                switch (operacao) {
                    case 1:
                        Depositar (service);
                        break;
                    case 2:
                        Sacar (service);
                        break;
                    case 3:
                        TranferirDinheiro (service, serviceContaBancaria);
                        break;
                    case 4:
                        ListarTransacoes (service);
                        break;
                    }
                } while (operacao != 5);
            }

        private static void ListarTransacoes ( ServiceOperacaoBancaria service )
            {
            List<Transacao> transacoes = service.ListTransations ();
            Console.WriteLine ("Lista de transacoes: ");
            long index = 1;
            if (transacoes.Count == 0)
                Console.WriteLine ("Nenhum transacao efetuada.");
            foreach (Transacao transacao in transacoes) {
                Console.WriteLine ($"\transacoes {index++}: " + transacao);

                }
            Console.WriteLine ("\nPrecione Enter para continuar.");
            Console.ReadKey ();
            }

        private static void TranferirDinheiro ( ServiceOperacaoBancaria service, ServiceContaBancaria serviceContaBancaria )
            {
            long numeroContaReceptora = Leitura.LerLongComMsg ("Numero da conta bancaria do receptor: ");
            ContaBancaria? receptor = serviceContaBancaria.FindById (numeroContaReceptora);
            if (receptor == null) {
                Console.WriteLine ("Esta conta nao esta cadastrada.");
                }
            else {
                double montante = Leitura.LerDoubleComMsg ("Valor da transferencia: R$ ");
                int flag = Leitura.LerFlagComMsg ("Tem certeza que deseja realizar essa operacao");
                if (flag == 1) {
                    try {
                        service.Transferencia (montante, receptor);

                        }
                    catch (Exception ex) { Console.WriteLine (ex.Message); }
                    }
                Console.WriteLine ("\nPrecione Enter para continuar.");
                Console.ReadKey ();
                }
            }
        private static void Sacar ( ServiceOperacaoBancaria service )
            {
            double montante = Leitura.LerDoubleComMsg ("Valor Saque R$: ");
            try {
                service.WithDraw (montante);
                }
            catch (Exception e) {
                Console.WriteLine (e.Message);
                }

            Console.WriteLine ("\nPrecione Enter para continuar.");
            Console.ReadKey ();
            }

        private static void Depositar ( ServiceOperacaoBancaria service )
            {
            double montante = Leitura.LerDoubleComMsg ("Valor Deposito R$: ");
            try {
                service.Deposit (montante);
                }
            catch (Exception e) {
                Console.WriteLine (e.Message);
                }

            Console.WriteLine ("\nPrecione Enter para continuar.");
            Console.ReadKey ();
            }
        }
    }
