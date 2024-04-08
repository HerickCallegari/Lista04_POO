using Banco.Views;
using Exercicio01.Model.entities;
using Exercicio01.Model.Services;
using Exercicio01.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Views
    {
    //Classe de interface grafica.
     internal class ViewCliente
        {
        public static void OperacoesCliente ( )
            {
            ServicesCliente service = new ServicesCliente ();

            int operacao = 1;
            do {
                Console.Clear ();
                if (operacao < 1 || operacao > 5)
                    Console.WriteLine ("Operacao invalida, digite novamente");
                Console.WriteLine ("-------- Cliente ---------");
                Console.WriteLine ("1) Cadastrar.");
                Console.WriteLine ("2) Listar.");
                Console.WriteLine ("3) Remover.");
                Console.WriteLine ("4) Modifica.");
                Console.WriteLine ("5) Voltar.");
                operacao = Leitura.LerIntComMsg ("\nDigite a operacao: ");
                switch (operacao) {
                    case 1:
                        CadastrarCliente (service);
                        break;
                    case 2:
                        ListarClientes (service);
                        break;
                    case 3:
                        RemoverCliente (service);
                        break;
                    case 4:
                        ModificaCliente (service);
                        break;
                    }
                } while (operacao != 5);
            
            }

        private static void ModificaCliente ( ServicesCliente service )
            {
            long cpf = Leitura.LerLongComMsg ("CPF do cliente que voce deseja modificar: ");
            Cliente? cliente = service.FindById (cpf);
            if ( cliente == null) {
                Console.WriteLine ("CPF nao cadastrado.");
                }
            else {
                Console.WriteLine ("Cliente: \n" + cliente);
                int operador;
                do {
                    operador = Leitura.LerIntComMsg ("\n Tem certeza que deseja modificar este cliente (1: sim) (2: nao): ");
                    if (operador != 1 && operador != 2) {
                        Console.WriteLine ("Digite 1 ou 2.");
                        }
                    } while (operador != 1 && operador != 2);

                if (operador == 1) {
                    Cliente clienteModificado = ViewForm.FormCliente (cliente.CPF);
                    try {
                        service.Update (clienteModificado);
                        } catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine ("Cliente Modificado com sucesso.");
                    }
                else {
                    Console.WriteLine ("Operacao finalizada.");
                    }
                Console.WriteLine ("\nPrecione Enter para continuar.");
                Console.ReadKey ();
                }
            }

        private static void RemoverCliente ( ServicesCliente service )
            {
            Console.Clear ();
            int operador;
            long id = Leitura.LerLongComMsg ("CPF do CLiente que voce deseja excluir: ");
            Cliente? cliente = service.FindById(id);

            if (cliente == null)
                Console.WriteLine ("Este cliente nao existe.");
            else if (cliente.Conta != null) {
                Console.WriteLine ("nao é possivel remover este cliente, pois ele possui uma conta bancaria em seu nome.");
                }
            else {
                Console.WriteLine (cliente);

                do {
                    operador = Leitura.LerIntComMsg ("Tem certeza que deseja excluir este cliente (1: sim) (2: nao):");
                    if (operador != 1 && operador != 2) {
                        Console.WriteLine ("Digite 1 ou 2.");
                        }
                    } while (operador != 1 && operador != 2);

                if (operador == 1) {
                    service.Remove (cliente);

                    Console.WriteLine ("Cliente removido com sucesso.");
                    }
                else {
                    Console.WriteLine ("Operacao finalizada.");
                    }
                }

            Console.WriteLine ("\nPrecione Enter para continuar.");
            Console.ReadKey ();
            }

        private static void ListarClientes ( ServicesCliente service )
            {
            
            Console.Clear ();
            List<Cliente> clientes = service.FindAll ();
            Console.WriteLine ("Lista de Clientes: ");
            int index = 1;
            if (clientes.Count == 0)
                Console.WriteLine ("Nenhum cliente cadastrado.");
            foreach (Cliente cliente in clientes) {
                Console.Write ($"\nCliente {index++}: ");
                Console.WriteLine (cliente);
                }
            Console.WriteLine ("\nPrecione Enter para continuar.");
            Console.ReadKey ();
            }

        private static void CadastrarCliente ( ServicesCliente service )
            {
            Cliente cliente = ViewForm.FormCliente ();
            if (service.FindById (cliente.CPF) == null) {
                service.Create(cliente);
                Console.WriteLine ("Cliente cadastrado com sucesso.");
                }
            else
                Console.WriteLine ("\nEste CPF ja esta cadastrado.");

            Console.WriteLine ("Precione Enter para continuar.");
            Console.ReadKey ();
            }

        }
    }
