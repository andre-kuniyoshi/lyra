using ahk.lyra.Domain.Enums;

namespace ahk.lyra.API.DTOs.Requests
{
    public class DocumentoRequestDTO
    {
        public TipoDocumento TipoDocumento { get; set; }
        public string Numero { get; set; }
    }
}
