using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ahk.lyra.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }
        public string Cep { get; private set; }

        public Endereco AtualizaEndereco(Endereco novoEndereco)
        {
            Logradouro = novoEndereco.Logradouro;
            Numero = novoEndereco.Numero;
            Complemento = novoEndereco.Complemento;
            Cidade = novoEndereco.Cidade;
            Cep = novoEndereco.Cep;

            return this;
        }
    }
}
