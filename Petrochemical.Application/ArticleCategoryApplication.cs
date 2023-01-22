using Petrochemical.ApplicationContracts.ArticleCategory;
using Petrochemical.Domain.ArticleCategoryAgg;

namespace Petrochemical.Application;

public class ArticleCategoryApplication : IArticleCategoryApplication
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }

    public void Create(ArticleCategoryOps command)
    {
        var articleCategory = new ArticleCategory(command.Name, command.ImagePath);

        _articleCategoryRepository.Create(articleCategory);
        _articleCategoryRepository.CommitTransaction();
    }

    public void Edit(ArticleCategoryOps command)
    {
        var articleCategory = _articleCategoryRepository
            .Get(command.Id);
        articleCategory.Edit(command.Name, command.ImagePath);
        //_articleCategoryRepository.Attach(articleCategory);
        _articleCategoryRepository.CommitTransaction();
    }

    public void Remove(long id)
    {
        var articleCategory = _articleCategoryRepository.Get(id);
        articleCategory.Removed();
        _articleCategoryRepository.CommitTransaction();
    }

    public void Restore(long id)
    {
        var articleCategory = _articleCategoryRepository.Get(id);
        articleCategory.Restore();
        _articleCategoryRepository.CommitTransaction();
    }
}