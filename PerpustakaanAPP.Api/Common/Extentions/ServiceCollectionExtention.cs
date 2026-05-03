using PerpustakaanAPP.Api.Areas.Auth.Services;
using PerpustakaanAPP.Api.Areas.Book.Services;

namespace PerpustakaanAPP.Api.Common.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped <AuthService>();
            services.AddScoped <BookService>();
            return services;
        }
    }
}