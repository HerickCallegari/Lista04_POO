using Banco.Model.Services;
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
        public static void OperacoesBancarias ( ) {
             ServiceContaBancaria service = new ServiceContaBancaria ();

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
                        service.CriarConta ();
                        break;
                    case 2:
                       // service.ListarContas ();
                        break;
                    case 3:
                        //service.ProcurarConta ();
                        break;
                    case 4:
                        //service.RemoverConta ();
                        break;
                    }
                } while (operacao != 5);
            }
        }
    }
