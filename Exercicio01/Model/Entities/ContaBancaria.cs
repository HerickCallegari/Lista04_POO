using Exercicio01.Model.Entities.associative;
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
        public long NumeroConta { get; set; }
        public Cliente Cliente { get; private set; }
        public double Saldo { get; private set; }
        public DateTime DataCriacao { get; set; }
        private List<Transacao> transacoes = new List<Transacao> ();
        public ContaBancaria ( long numeroConta, Cliente cliente )
            {
            Cliente = cliente;
            NumeroConta = numeroConta;
            DataCriacao = DateTime.Now;
            Saldo = 0;
            Cliente.TrocaConta (this);
            }
        public List<Transacao> GetTransacaos ( )
            {
            return transacoes;
            }
        public void Transferir (ContaBancaria receptor, double montante)
            {
            Transacao transacao = new Transacao (this, receptor);
            transacao.Transferir(montante);
            }
        public void AddTransacao( Transacao transacao )
            {
            transacoes.Add(transacao);
            }
        public void RemoveTransacao ( Transacao transacao )
            {
            transacoes.Remove (transacao);
            }
        public void SacarSemJuros ( double montante )
            {
            if (montante <= Saldo)
                Saldo -= montante;
            else if (montante <= 0) {
                throw new Exception ("Digite um valor maior que 0");
                }
            else
                throw new Exception ("Saldo insuficiente.");
            }
        public void Sacar(double montante)
            {
            double taxa = 0;
            if (montante <= Saldo)
                Saldo -= montante + taxa;
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
        public void TrocaCliente(Cliente cliente )
            {
            if (cliente != null)
                Cliente = cliente;
            else
                throw new Exception ("Cliente nao nullo.");
            }
        public override string ToString ( )
            {
            return "Conta numero: " + NumeroConta +
                   "\nCliente: " + Cliente +
                   "\nData de Criacao: " + DataCriacao.ToString("dd/MM/yyyy") +
                   "\nSaldo: R$ " + Saldo.ToString("F2");
             }

        }
    }
