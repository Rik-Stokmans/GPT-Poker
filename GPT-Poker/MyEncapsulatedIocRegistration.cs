using DataLayer.Services;
using LogicLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GPT_Poker;

public static class MyEncapsulatedIocRegistration
{
    public static IServiceCollection AddType<T>(this IServiceCollection services) where T : class, new()
    {
        services.AddScoped<IDatabaseEntityService<T>, DatabaseEntityService<T>>();

        return services;
    }
}