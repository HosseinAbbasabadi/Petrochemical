using Microsoft.Extensions.DependencyInjection;

namespace _0_Framework.Infrastructure;

public class FrameworkModule
{
    public static void Config(IServiceCollection services)
    {
        services.AddTransient<BaseDapperRepository>();
        services.AddTransient<IConnectionStringBuilder, ConnectionStringBuilder>();
    }
}