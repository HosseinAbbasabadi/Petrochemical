using _0_Framework.Application;
using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Petrochemical.Application;
using Petrochemical.Infrastructure.EfCore;
using Petrochemical.Infrastructure.Query;
using Microsoft.Extensions.DependencyInjection;
using Petrochemical.Infrastructure.EfCore.Repository;

namespace Petrochemical.Infrastructure.Configuration;

public class PetrochemicalModule
{
    public static void Config(IServiceCollection services, string connectionString)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<ArticleCategoryRepository>()
            .AddClasses(x => x.AssignableTo(typeof(IRepository<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.Scan(scan => scan
            .FromAssemblyOf<ArticleCategoryApplication>()
            .AddClasses(x => x.AssignableTo(typeof(IApplication)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.Scan(scan => scan
            .FromAssemblyOf<ArticleCategoryQuery>()
            .AddClasses(x => x.AssignableTo(typeof(IQuery)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        //services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
        //services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
        //services.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();

        services.AddDbContext<PetroContext>(x
            => x.UseSqlServer(connectionString));
    }
}