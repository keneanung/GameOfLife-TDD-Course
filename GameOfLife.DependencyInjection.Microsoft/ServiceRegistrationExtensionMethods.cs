using GameOfLife.Lib.Domain;
using GameOfLife.Lib.Logic;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegistrationExtensionMethods
    {
        public static void UseGameOfLife(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICoreRule, CoreRule>()
                .AddSingleton<IGameOfLifeFactory, GameOfLifeFactory>();
        }
    }
}