using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petrochemical.Domain.ArticleCategoryAgg;

namespace Petrochemical.Infrastructure.EfCore.Mapping;

internal class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
{
    public void Configure(EntityTypeBuilder<ArticleCategory> builder)
    {
        builder.ToTable("tbArticleCategory");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(250)
            .IsRequired();
    }
}