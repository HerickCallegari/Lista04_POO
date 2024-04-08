using Exercicio01.Model.entities;
using Exercicio01.Model.Entities.associative;

namespace Banco.Model.Services
    {
    internal class ServiceContaBancaria
        {
        //Simular conexao com banco
        public static List<ContaBancaria> contas = new List<ContaBancaria> ();
        public void Create ( ContaBancaria conta )
            {
            contas.Add (conta);
            }

        public List<ContaBancaria> FindAll ( )
            {
            return contas;
            }
        public void Remove ( ContaBancaria conta )
            {
            Cliente cliente = conta.Cliente;
            cliente.RemoverConta ();
            contas.Remove (conta);
            }
        public ContaBancaria? FindById ( long id )
            {

            foreach (ContaBancaria conta in contas) {
                if (conta.NumeroConta == id)
                    return conta;
                }
            return null;
            }
        public void WithDraw ( ContaBancaria conta, double montante )
            {
            try {
                conta.Sacar (montante);
                }
            catch (Exception) {
                throw;
                }
            }
        public void Deposit ( ContaBancaria conta, double montante )
            {
            try {
                conta.Deposito (montante);
                }
            catch (Exception) {
                throw;
                }
            }
        public void Transferencia( ContaBancaria emissor, double montante, ContaBancaria receptor )
            {
            if ( montante < 0 ) {
                throw new Exception ("Montante menor ou igual a 0");
                }
            if ( emissor == null) {
                throw new Exception ("Conta emissora nula");
                }
            if (receptor == null) {
                throw new Exception ("Conta receptora nula");
                }
            emissor.Transferir(receptor, montante);
            }
        public List<Transacao> ListTransations ( ContaBancaria conta )
            {
            return conta.GetTransacaos();
            }

        }
    }
