using ahk.lyra.API.DTOs.Requests;
using ahk.lyra.Domain.Entities;
using AutoMapper;

namespace ahk.lyra.API.Configurations
{
    public class AutoMapperConfigurations : Profile
    {
        public AutoMapperConfigurations()
        {
            CreateMap<CadastroUsuarioRequestDTO, Usuario>();
            CreateMap<EnderecoRequestDTO, Endereco>();
            CreateMap<DocumentoRequestDTO, Documento>();
            CreateMap<TelefoneRequestDTO, Telefone>();
        }
    }
}
