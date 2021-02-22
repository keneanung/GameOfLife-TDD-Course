using GameOfLife.Lib.Domain;
using GameOfLife.Lib.Logic;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegistrationExtensionMethods
    {
        public static IServiceCollection UseGameOfLife(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton<ICoreRule, CoreRule>()
                .AddSingleton<IGameOfLifeFactory, GameOfLifeFactory>();
        }
    }
}