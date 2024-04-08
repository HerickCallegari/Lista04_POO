using Banco.Model.Entities;
using Exercicio01.Model.entities;
using Exercicio01.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Views
    {
    internal class ViewForm
        {
        public static Cliente FormCliente()
            {

            string nome;
            long cpf;
            string email;
            string rua;
            string bairro;
            string cidade;
            string estado;
            string telefone;

            nome = Leitura.LerStringComMsg ("Nome: ");
            cpf = Leitura.LerLongComMsg ("CPF: ");
            email = Leitura.LerStringComMsg ("Email: ");
            rua = Leitura.LerStringComMsg ("Rua: ");
            bairro = Leitura.LerStringComMsg ("Bairro: ");
            estado = Leitura.LerStringComMsg ("Estado: ");
            cidade = Leitura.LerStringComMsg ("Cidade: ");
            telefone = Leitura.LerStringComMsg ("Telefone: ");
            return new Cliente (nome, cpf, email, new Endereco(rua,bairro,cidade,estado), telefone);
            }
        public static Cliente FormCliente ( long cpf)
            {

            string nome;
            string email;
            string rua;
            string bairro;
            string cidade;
            string estado;
            string telefone;

            nome = Leitura.LerStringComMsg ("Nome: ");
            Console.WriteLine("CPF: " + cpf);
            email = Leitura.LerStringComMsg ("Email: ");
            rua = Leitura.LerStringComMsg ("Rua: ");
            bairro = Leitura.LerStringComMsg ("Bairro: ");
            estado = Leitura.LerStringComMsg ("Estado: ");
            cidade = Leitura.LerStringComMsg ("Cidade: ");
            telefone = Leitura.LerStringComMsg ("Telefone: ");
            return new Cliente (nome, cpf, email, new Endereco (rua, bairro, cidade, estado), telefone);
            }
        }
    }
