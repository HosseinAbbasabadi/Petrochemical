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
        _articleCategoryRepository.Commit();
    }

    public void Edit(ArticleCategoryOps command)
    {
        var articleCategory = _articleCategoryRepository
            .GetById(command.Id);
        articleCategory.Edit(command.Name, command.ImagePath);
        //_articleCategoryRepository.Attach(articleCategory);
        _articleCategoryRepository.Commit();
    }

    public void Remove(long id)
    {
        var articleCategory = _articleCategoryRepository.GetById(id);
        articleCategory.Removed();
        _articleCategoryRepository.Commit();
    }

    public void Restore(long id)
    {
        var articleCategory = _articleCategoryRepository.GetById(id);
        articleCategory.Restore();
        _articleCategoryRepository.Commit();
    }
}