using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Model.entities
    {
    //Cliente: Usuario alvo da aplicação
    internal class Cliente ( string nome, int cpf, string email, string endereco, string telefone )
        {
        public int CPF { get; set; } = cpf;
        public string Nome { get; set; } = nome;
        public string Email { get; set; } = email;
        public string Endereco { get; set; } = endereco;
        public string Telefone { get; set; } = telefone;
        public ContaBancaria? Conta { get; set; } = null;

        public void AtualizarEndereco( string endereco )
            {
            Endereco = endereco;
            }

        public void AtualizarTelefone( string telefone )
            {
            Telefone = telefone;
            }
        public override string ToString ( )
            {
            return "\nNome: " + Nome +
                   "\nCPF: " + CPF +
                   "\nEmail: " + Email +
                   "\nTelefone: " + Telefone +
                   "\nEndereco: " + Endereco;
            }
        }
    }
