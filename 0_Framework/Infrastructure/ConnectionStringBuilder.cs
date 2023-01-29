using Microsoft.Extensions.Configuration;

namespace _0_Framework.Infrastructure;

internal class ConnectionStringBuilder : IConnectionStringBuilder
{
    private readonly IConfiguration _configuration;

    public ConnectionStringBuilder(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Build()
    {
        return _configuration.GetConnectionString("Petro") ?? "";
    }
}