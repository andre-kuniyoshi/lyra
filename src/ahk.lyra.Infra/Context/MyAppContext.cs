using ahk.lyra.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ahk.lyra.Infra.Context
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Documento> Documentos{ get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Contatos{ get; set; }
    }
}
