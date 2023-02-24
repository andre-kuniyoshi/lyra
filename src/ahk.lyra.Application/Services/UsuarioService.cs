using ahk.lyra.Application.Notification;
using ahk.lyra.Domain.Entities;
using ahk.lyra.Domain.Repositories;
using ahk.lyra.Domain.Services;

namespace ahk.lyra.Application.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository, INotifier notifier) : base(notifier)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario?> BuscaUsuarioPorID(Guid id)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioCompleto(id);
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> BuscaTodosUsuarios()
        {
            var usuarios = await _usuarioRepository.ListAll();
            return usuarios;
        }

        public async Task<Usuario?> AdicionaUsuario(Usuario usuario)
        {
            var existeEmail = await _usuarioRepository.ExisteEmail(usuario.Email);

            if (existeEmail)
            {
                AddNotification("Email", "Email já cadastrado");
                return null;
            }

            await _usuarioRepository.Add(usuario);
            return usuario;
        }

        public async Task<Usuario?> AtualizaUsuario(Guid id, Usuario novoUsuario)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioCompleto(id);

            if (usuario == null)
            {
                AddNotification("Id", "Usuario informado não existe.");
                return null;
            }

            usuario.Atualiza(novoUsuario);
            await _usuarioRepository.Update(usuario);
            return usuario;
        }

        public async Task<bool> DeletaUsuario(Guid id)
        {
            var existeUsuario = await _usuarioRepository.Exists(x => x.Id == id);
            if (!existeUsuario)
            {
                AddNotification("Id", "Usuario informado não existe.");
                return false;
            }

            return await _usuarioRepository.Delete(id);
        }
    }
}
