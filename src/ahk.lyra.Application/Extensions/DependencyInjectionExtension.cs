using ahk.lyra.Application.Notification;
using ahk.lyra.Application.Services;
using ahk.lyra.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ahk.lyra.Application.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
