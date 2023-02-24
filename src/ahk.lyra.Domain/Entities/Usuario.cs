using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ahk.lyra.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public string Sexo { get; private set; }
        public string Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public IEnumerable<Documento> Documentos { get; private set; }
        public IEnumerable<Telefone> Telefones { get; private set; }

        public void Atualiza(Usuario novoUsuario)
        {
            Nome = novoUsuario.Nome;
            Idade = novoUsuario.Idade;
            Sexo = novoUsuario.Sexo;
            Email = novoUsuario.Email;

            Endereco = Endereco.AtualizaEndereco(novoUsuario.Endereco);

            Documentos = novoUsuario.Documentos;
            Telefones = novoUsuario.Telefones;
        }

    }
}
