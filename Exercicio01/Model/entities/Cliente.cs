using Banco.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Model.entities
    {
    //Cliente: Usuario alvo da aplicação
    internal class Cliente ( string nome, long cpf, string email, Endereco endereco, string telefone )
        {
        public long CPF { get; set; } = cpf;
        public string Nome { get; set; } = nome;
        public string Email { get; set; } = email;
        public Endereco Endereco { get; set; } = endereco;
        public string Telefone { get; set; } = telefone;
        public ContaBancaria? Conta { get;  private set; } = null;

        public void AtualizarEndereco( Endereco endereco )
            {
            Endereco = endereco;
            }

        public void AtualizarTelefone( string telefone )
            {
            Telefone = telefone;
            }

        public void TrocaConta(ContaBancaria contaBancaria )
            {
            if (contaBancaria != null)
                Conta = contaBancaria;
            else
                throw new Exception ("Conta nao nulla.");
            }
        public void RemoverConta()
            {
            Conta = null;
            }
        public override string ToString ( )
            {
            return "\nNome: " + Nome +
                   "\nCPF: " + CPF +
                   "\nEmail: " + Email +
                   "\nTelefone: " + Telefone +
                   "\nEndereco: " + Endereco +
                   "\nPossui conta: " + (Conta == null ? "False" : "True");

            }
        }
    }
