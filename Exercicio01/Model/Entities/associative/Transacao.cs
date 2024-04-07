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
        public string? Operacao { get; private set; }
        private double _montante;

        public Transacao(ContaBancaria emissor, ContaBancaria receptor)
        {
            Emissor = emissor;
            Receptor = receptor;
            _montante = 0.0;
            TipoOperacao(0);
        }
        public Transacao(ContaBancaria emissor, ContaBancaria receptor, double montante)
        {
            Emissor = emissor;
            Receptor = receptor;
            _montante = montante;
            TipoOperacao(0);
        }
        public void Transferir(double montante)
        {
            try
            {
                Emissor.Sacar(montante);
                Receptor.Deposito(montante);
                _montante = montante;
                TipoOperacao(1);

                Transacao recebe = new Transacao(Receptor, Emissor, montante);
                recebe.TipoOperacao(2);
                Receptor.RecebeDe(recebe);
            }
            catch (Exception)
            {
                TipoOperacao(0);
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
                return Emissor.Cliente.Nome + Operacao + Receptor.Cliente.Nome + ", um valor de R$ " + _montante;
            else
                return "Falha na operacao de transacao";
        }


    }
}
