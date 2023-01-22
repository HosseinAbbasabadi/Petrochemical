using _0_Framework.Infrastructure;
using Petrochemical.Domain.ArticleCategoryAgg;

namespace Petrochemical.Infrastructure.EfCore.Repository;

public class ArticleCategoryRepository : BaseRepository<long, ArticleCategory>, IArticleCategoryRepository
{
    private readonly PetroContext _context;

    public ArticleCategoryRepository(PetroContext context) : base(context)
    {
        _context = context;
    }
}