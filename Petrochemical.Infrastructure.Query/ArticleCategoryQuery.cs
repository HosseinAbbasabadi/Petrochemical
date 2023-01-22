using Petrochemical.Infrastructure.EfCore;
using Petrochemical.ApplicationContracts.ArticleCategory;

namespace Petrochemical.Infrastructure.Query;

public class ArticleCategoryQuery : IArticleCategoryQuery
{
    private readonly PetroContext _petroContext;

    public ArticleCategoryQuery(PetroContext petroContext)
    {
        _petroContext = petroContext;
    }

    public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
    {
        var query = _petroContext.ArticleCategories
            .Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath,
                IsRemoved = x.IsRemoved
            });

        if (searchModel.Id > 0)
            query = query.Where(x => x.Id == searchModel.Id);

        if (!string.IsNullOrWhiteSpace(searchModel.Name))
            query = query.Where(x => x.Name.Contains(searchModel.Name));

        if (searchModel.Status == 1)
            query = query.Where(x => !x.IsRemoved);

        if (searchModel.Status == 2)
            query = query.Where(x => x.IsRemoved);

        return query.ToList();
    }

    public ArticleCategoryOps GetForEdit(long id)
    {
        return _petroContext.ArticleCategories
            .Select(x => new ArticleCategoryOps
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath
            }).First(x => x.Id == id);
    }
}