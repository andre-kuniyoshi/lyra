using ahk.lyra.Domain.Entities;

namespace ahk.lyra.Domain.Services
{
    public interface IUsuarioService
    {
        public Task<Usuario?> BuscaUsuarioPorID(Guid id);
        public Task<IEnumerable<Usuario>> BuscaTodosUsuarios();
        public Task<Usuario?> AdicionaUsuario(Usuario usuario);
        public Task<Usuario?> AtualizaUsuario(Guid id, Usuario novoUsuario);
        public Task<bool> DeletaUsuario(Guid id);
    }
}
