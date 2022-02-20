using LibApp.Data.Repository.Interfaces;
using LibApp.Data.Repository.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Data.Repository
{
    public static class RepositoryInstaller
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();

            return services;
        }
    }
}
