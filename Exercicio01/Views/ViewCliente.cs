using Biblioteca;
using Exercicio01.Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Views
    {
    //Classe de interface grafica.
     class ViewCliente
        {
        /* 
         * como a aplicacao nao esta conectada a banco de dados
         * decidi fazer uma lista de clientes statica para simular
         * o armazenamento de informações e clientes dentro do
         * possivel com as tecnologias disponibilizadas pelo 
         * professor
         */
        public static List<Cliente> clientes = new List<Cliente>(); 
        public static void OperacoesCliente ( )
            {

            int operacao = 1;
            do {
                Console.Clear ();
                if (operacao < 1 || operacao > 4)
                    Console.WriteLine ("Operacao invalida, digite novamente");
                Console.WriteLine ("-------- Operacoes Cliente ---------");
                Console.WriteLine ("1) Cadastrar.");
                Console.WriteLine ("2) Listar.");
                Console.WriteLine ("3) Remover.");
                Console.WriteLine ("4) Encerrar.");
                operacao = Leitura.LerIntComMsg ("\nDigite a operacao: ");
                switch (operacao) {
                    case 1:
                        CadastrarCliente ();
                        break;
                    case 2:
                        ListarClientes ();
                        break;
                    case 3:
                        RemoverCliente ();
                        break;
                    case 4:
                        break;
                    }
                } while (operacao != 4);
            }

        public static void CadastrarCliente ( )
            {

            string nome;
            int cpf;
            string email;
            string endereco;
            string telefone;

            nome = Leitura.LerStringComMsg ("Nome: ");
            cpf = Leitura.LerIntComMsg ("CPF: ");
            email = Leitura.LerStringComMsg ("Email: ");
            endereco = Leitura.LerStringComMsg ("Endereco: ");
            telefone = Leitura.LerStringComMsg ("Telefone: ");
            if (ProcurarCliente (cpf) == null) {
                clientes.Add (new Cliente (nome, cpf, email, endereco, telefone));
                Console.WriteLine ("Cliente cadastrado com sucesso.");
                }
            else
                Console.WriteLine ("\nEste CPF ja esta cadastrado.");

            Console.WriteLine("Precione Enter para continuar.");
            Console.ReadKey ();
            }
        public static Cliente? ProcurarCliente ( int id )
        {

            foreach (Cliente cliente in clientes) {
                if (cliente.CPF == id)
                    return cliente;
                }
            return null;
            }

        public static void ListarClientes ( )
            {
            Console.Clear ();
            Console.WriteLine("Lista de Clientes: ");
            int index = 0;
            if (clientes.Count == 0)
                Console.WriteLine ("Nenhum cliente cadastrado.");
            foreach (Cliente cliente in clientes) {
                Console.Write ($"\nCliente {index++}: ");
                Console.WriteLine (cliente);
                }
            Console.WriteLine ("\nPrecione Enter para continuar.");
            Console.ReadKey ();
            }
        public static void RemoverCliente ( )
            {
            Console.Clear ();
            int operador;
            int id = Leitura.LerIntComMsg ("CPF do CLiente que voce deseja excluir: ");
            Cliente? cliente = ProcurarCliente (id);

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
                    clientes.Remove (cliente);

                    Console.WriteLine ("Cliente removido com sucesso.");
                    }
                else {
                    Console.WriteLine ("Operacao finalizada.");
                    }
                }

            Console.WriteLine ("\nPrecione Enter para continuar.");
            Console.ReadKey ();
            }

        }
    }
