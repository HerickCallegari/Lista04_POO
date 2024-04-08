using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Model.Entities
    {
    internal class Endereco
        {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Endereco(string rua, string bairro, string cidade, string estado) { 
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            }
        public override string ToString ( )
            {
            return "\nRua: " + Rua +
                   "\nBairro: " + Bairro +
                   "\nCidade: " + Cidade +
                   "\nEstado: " + Estado;
            }
        }
    }
