using ahk.lyra.Domain.Enums;

namespace ahk.lyra.Domain.Entities
{
    public class Documento : BaseEntity
    {
        public TipoDocumento TipoDocumento { get; private set; }
        public string Numero { get; private set; }
    }
}
