using ahk.lyra.Domain.Entities;

namespace ahk.lyra.Domain.Repositories
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        public Task<Usuario?> BuscarUsuarioCompleto(Guid id);
        public Task<IEnumerable<Usuario>> BuscarTodosUsuariosCompleto();
        public Task<bool> ExisteEmail(string email);
    }
}
