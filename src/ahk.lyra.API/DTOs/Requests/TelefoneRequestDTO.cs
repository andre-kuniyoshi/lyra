using ahk.lyra.Domain.Enums;

namespace ahk.lyra.API.DTOs.Requests
{
    public class TelefoneRequestDTO
    {
        public TipoTelefone TipoTelefone { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
    }
}
