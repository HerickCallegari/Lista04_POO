using Exercicio01.Model.entities;

namespace Exercicio01.Model.Services
    {
    //Classe responsavel pelo crud
    internal class ServicesCliente
        {
        /* 
         * como a aplicacao nao esta conectada a banco de dados
         * decidi fazer uma lista de clientes statica para simular
         * o armazenamento de informações e clientes 
         * com as tecnologias disponibilizadas pelo professor
         */
        public static List<Cliente> clientes = new List<Cliente> ();
        public void Create ( Cliente cliente )
            {
            clientes.Add (cliente);
            }
        public Cliente? FindById ( long id )
            {

            foreach (Cliente cliente in clientes) {
                if (cliente.CPF == id)
                    return cliente;
                }
            return null;
            }

        public List<Cliente> FindAll ( )
            {
            return clientes;
            }

        public void Remove ( Cliente cliente )
            {
            clientes.Remove (cliente);
            }

        public void Update ( Cliente cliente )
            {

            Cliente? clienteAntigo = FindById (cliente.CPF);

            if (clienteAntigo == null) {
                throw new Exception ("Erro ao fazer o upload!");
                }
            if (clienteAntigo.Conta != null) {
                ContaBancaria contaClienteAntigo = clienteAntigo.Conta;
                try {
                    cliente.TrocaConta (contaClienteAntigo);
                    contaClienteAntigo.TrocaCliente (cliente);
                    }
                catch (Exception) {
                    throw;
                    }
                }
            clientes.Remove (clienteAntigo);
            clientes.Add (cliente);

            }

        }
    }
