using _0_Framework.Application;
using Petrochemical.ApplicationContracts;
using Petrochemical.ApplicationContracts.ArticleCategory;
using Petrochemical.Domain.ArticleCategoryAgg;
using Petrochemical.Domain.ArticleCategoryAgg.Service;

namespace Petrochemical.Application;

public class ArticleCategoryApplication : IArticleCategoryApplication
{
    private const string TableName = "ArticleCategory";
    private readonly IArticleCategoryRepository _articleCategoryRepository;
    private readonly IArticleCategoryService _articleCategoryService;

    public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository,
        IArticleCategoryService articleCategoryService)
    {
        _articleCategoryRepository = articleCategoryRepository;
        _articleCategoryService = articleCategoryService;
    }

    public OperationResult Create(ArticleCategoryOps command)
    {
        var operation = new OperationResult(TableName).IsCreate();

        if (_articleCategoryService.IsNameDuplicated(command.Name))
            return operation.Failure(ApplicationMessages.DuplicatedError);

        var articleCategory = new ArticleCategory(command.Name, command.ImagePath);
        _articleCategoryRepository.Create(articleCategory);
        _articleCategoryRepository.CommitTransaction();

        return operation.SetId(articleCategory.Id)
            .Success();
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