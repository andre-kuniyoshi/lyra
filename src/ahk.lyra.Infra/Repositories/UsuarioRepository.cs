using ahk.lyra.Domain.Entities;
using ahk.lyra.Domain.Repositories;
using ahk.lyra.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ahk.lyra.Infra.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MyAppContext context) : base(context)
        {
        }

        public async Task<Usuario?> BuscarUsuarioCompleto(Guid id)
        {
            return await DbSet.AsNoTracking()
                .Include(p => p.Documentos)
                .Include(p => p.Endereco)
                .Include(p => p.Telefones)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Usuario>> BuscarTodosUsuariosCompleto()
        {
            return await DbSet.AsNoTracking()
                .Include(p => p.Documentos)
                .Include(p => p.Endereco)
                .Include(p => p.Telefones)
                .ToListAsync();
        }

        public async Task<bool> ExisteEmail(string email)
        {
            var usuario = await FindOne(x => x.Email == email);
            return usuario != null;
        }
    }
}
