using Exercicio01.Model.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Model.Entities.associative
{
    // Classe associativa de conta bancaria com conta bancaria
    internal class Transacao
        {
        public ContaBancaria Emissor { get; private set; }
        public ContaBancaria Receptor { get; set; }
        public DateTime Data {  get; private set; }
        public string? Operacao { get; private set; }

        public double Montante { get; set; }

        public Transacao ( ContaBancaria emissor, ContaBancaria receptor)
        {
            Data = DateTime.Now;
            Emissor = emissor;
            Receptor = receptor;
            Montante = 0.0;
            TipoOperacao(0);
        }
        public Transacao ( ContaBancaria emissor, ContaBancaria receptor, double montante, int tipoOperacao)
        {
            Data = Data = DateTime.Now;
            Emissor = emissor;
            Receptor = receptor;
            Montante = montante;
            TipoOperacao(tipoOperacao);
        }
        public void Transferir(double montante)
        {
           try {
                Montante = montante;
                Emissor.SacarSemJuros (montante);
                Receptor.Deposito (montante);
                TipoOperacao (1);
                Emissor.AddTransacao (this);
                Receptor.AddTransacao (new Transacao (Receptor, Emissor, montante, 2));
                }catch (Exception) {
                throw;
                }
        }

        public void TipoOperacao(int tipo)
        {
            Operacao = tipo switch
            {
                0 => "",
                1 => " Depositou para ",
                2 => " Recebeu de ",
                _ => "",
            };
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Operacao))
                return Emissor.Cliente.Nome + Operacao + Receptor.Cliente.Nome + ", um valor de R$ " + Montante.ToString("F2") + " | " + Data;
            else
                return "Falha na operacao de transacao" + " | " + Data.ToString ();
        }


    }
}
