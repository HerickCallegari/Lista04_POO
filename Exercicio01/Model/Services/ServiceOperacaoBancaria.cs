using Exercicio01.Model.entities;
using Exercicio01.Model.Entities.associative;

namespace Banco.Model.Services
    {
    internal class ServiceOperacaoBancaria ( ContaBancaria conta )
        {
        private ContaBancaria conta = conta;

        public void WithDraw ( double montante )
            {
            try {
                conta.Sacar (montante);
                }
            catch (Exception) {
                throw;
                }
            }
        public void Deposit ( double montante )
            {
            try {
                conta.Deposito (montante);
                }
            catch (Exception) {
                throw;
                }
            }
        public void Transferencia ( double montante, ContaBancaria receptor )
            {
            if (montante < 0) {
                throw new Exception ("Montante menor ou igual a 0");
                }
            if (conta == null) {
                throw new Exception ("Conta emissora nula");
                }
            if (receptor == null) {
                throw new Exception ("Conta receptora nula");
                }
            conta.Transferir (receptor, montante);
            }
        public List<Transacao> ListTransations ( )
            {
            return conta.GetTransacaos ();
            }
        }
    }
