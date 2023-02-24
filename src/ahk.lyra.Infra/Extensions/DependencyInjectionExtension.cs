using ahk.lyra.Application.Services;
using ahk.lyra.Domain.Repositories;
using ahk.lyra.Domain.Services;
using ahk.lyra.Infra.Context;
using ahk.lyra.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ahk.lyra.Infra.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<MyAppContext>(opt => opt.UseInMemoryDatabase("LyraTesteDB"));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }
    }
}
