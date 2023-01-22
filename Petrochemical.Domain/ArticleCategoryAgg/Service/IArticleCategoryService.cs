using _0_Framework.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Petrochemical.Domain.ArticleCategoryAgg.Service;

public interface IArticleCategoryService : IDomainService
{
    bool IsNameDuplicated(string name);
}

public class ArticleCategoryService : IArticleCategoryService
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleCategoryService(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }

    public bool IsNameDuplicated(string name)
    {
        return _articleCategoryRepository.Exists(x => x.Name == name);
    }
}