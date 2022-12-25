using Microsoft.EntityFrameworkCore;
using Petrochemical.Domain.ArticleCategoryAgg;
using Petrochemical.Infrastructure.EfCore.Mapping;

namespace Petrochemical.Infrastructure.EfCore;

public class PetroContext : DbContext
{
    public DbSet<ArticleCategory> ArticleCategories { get; set; }

    public PetroContext(DbContextOptions<PetroContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(ArticleCategoryMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(modelBuilder);
    }
}