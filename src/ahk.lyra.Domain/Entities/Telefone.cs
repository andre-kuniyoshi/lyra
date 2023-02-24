using ahk.lyra.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ahk.lyra.Domain.Entities
{
    public class Telefone : BaseEntity
    {
        public TipoTelefone TipoTelefone { get; private set; }
        public string DDD { get; private set; }
        public string Numero { get; private set; }

    }
}
