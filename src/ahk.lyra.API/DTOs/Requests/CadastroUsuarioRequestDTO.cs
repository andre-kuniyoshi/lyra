
namespace ahk.lyra.API.DTOs.Requests
{
    public class CadastroUsuarioRequestDTO
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public EnderecoRequestDTO Endereco { get; set; }
        public IEnumerable<DocumentoRequestDTO> Documentos { get; set; }
        public IEnumerable<TelefoneRequestDTO> Telefones { get; set; }
    }
}
