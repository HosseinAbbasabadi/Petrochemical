using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Petrochemical.Application;
using Petrochemical.ApplicationContracts.ArticleCategory;
using Petrochemical.Domain.ArticleCategoryAgg;
using Petrochemical.Infrastructure.EfCore;
using Petrochemical.Infrastructure.EfCore.Repository;

namespace Petrochemical.Infrastructure.Configuration;

public class PetrochemicalModule
{
    public static void Config(IServiceCollection services, string connectionString)
    {
        services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
        services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

        services.AddDbContext<PetroContext>(x
            => x.UseSqlServer(connectionString));
    }
}