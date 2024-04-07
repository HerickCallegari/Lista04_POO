using Exercicio01.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Model.entities
    {
    // classe responsavel por armazenar as transações e saldo do cliente
    internal class ContaBancaria
        {
        public int NumeroConta { get; set; }
        public Cliente Cliente { get; private set; }
        public double Saldo { get; private set; }
        public DateTime DataCriacao { get; set; }
        private List<Transacao> transacoes = new List<Transacao>();
        public ContaBancaria ( int numeroConta, Cliente cliente )
            {
            Cliente = cliente;
            NumeroConta = numeroConta;
            DataCriacao = DateTime.Now;
            Saldo = 0;
            Cliente.Conta = this;
            }
        public List<Transacao> GetTransacaos ( )
            {
            return transacoes;
            }
        public void TranferirPara(double montante, ContaBancaria receptor)
            {
            Transacao transacao = new Transacao (this, receptor);
            transacao.Transferir(montante);
            transacoes.Add(transacao);
            }
        public void RecebeDe(Transacao transacao)
            {
            transacoes.Add (transacao);
            }
        public void Sacar(double montante)
            {
            if (montante <= Saldo)
                Saldo -= montante;
            else if (montante <= 0 ) {
                throw new Exception ("Digite um valor maior que 0");
                }
            else
                throw new Exception ("Saldo insuficiente.");
            }
        public void Deposito(double montante)
            {
            if (montante > 0)
                Saldo += montante;
            else
                throw new Exception ("O valor deve ser maior que 0.");
                
            }
        public override string ToString ( )
            {
            return "Conta numero: " + NumeroConta +
                   "\nCliente: " + Cliente +
                   "\nData de Criacao: " + DataCriacao.ToString("dd/MM/yyyy") +
                   "\nSaldo: " + Saldo;
             }

        }
    }
