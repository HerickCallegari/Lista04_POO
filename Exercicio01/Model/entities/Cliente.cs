using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Model.entities
    {
    internal class Cliente
        {
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string ENDERECO { get; set; }
        public string TELEFONE { get; set; }

        public Cliente ( ) { }

        public Cliente ( string nome, string email, string endereco, string telefone ) : this()
            {
            NOME = nome;
            EMAIL = email;
            ENDERECO = endereco;
            TELEFONE = telefone;
            }

        public void AtualizarEndereco( string endereco )
            {
            ENDERECO = endereco;
            }

        public void AtualizarTelefone( string telefone )
            {
            TELEFONE = telefone;
            }

        }
    }
