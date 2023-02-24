namespace ahk.lyra.API.DTOs.Requests
{
    public class EnderecoRequestDTO
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
    }
}
