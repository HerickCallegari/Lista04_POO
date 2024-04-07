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
                if (operacao < 1 || operacao > 4)
                    Console.WriteLine ("Operacao invalida, digite novamente");
                Console.WriteLine ("-------- Operacoes Cliente ---------");
                Console.WriteLine ("1) Cadastrar.");
                Console.WriteLine ("2) Listar.");
                Console.WriteLine ("3) Remover.");
                Console.WriteLine ("4) Modifica.");
                Console.WriteLine ("5) Voltar.");
                operacao = Leitura.LerIntComMsg ("\nDigite a operacao: ");
                switch (operacao) {
                    case 1:
                        service.CadastrarCliente ();
                        break;
                    case 2:
                        service.ListarClientes ();
                        break;
                    case 3:
                        service.RemoverCliente ();
                        break;
                    case 4:
                        break;
                    }
                } while (operacao != 4);
            }
       
        }
    }
