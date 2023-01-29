using _0_Framework.Infrastructure;
using Petrochemical.Infrastructure.EfCore;
using Petrochemical.ApplicationContracts.ArticleCategory;

namespace Petrochemical.Infrastructure.Query;

public class ArticleCategoryQuery : IArticleCategoryQuery
{
    private readonly PetroContext _petroContext;
    private readonly BaseDapperRepository _dapperRepository;

    public ArticleCategoryQuery(PetroContext petroContext, BaseDapperRepository dapperRepository)
    {
        _petroContext = petroContext;
        _dapperRepository = dapperRepository;
    }

    public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
    {
        var query = _petroContext.ArticleCategories
            .Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath,
                IsRemoved = x.IsRemoved,
                RemoveState = x.IsRemoved.IndicateRemoveState()
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
        //_dapperRepository.SelectFromSp<ArticleCategoryOps>("EXAMPLE_PROCEDURE", new { Id = id });
        return _dapperRepository.SelectFirstOrDefault<ArticleCategoryOps>(
            @$"SELECT Id, Name, ImagePath FROM tbArticleCategory WHERE ID = {id}");

        //return _petroContext.ArticleCategories
        //    .Select(x => new ArticleCategoryOps
        //    {
        //        Id = x.Id,
        //        Name = x.Name,
        //        ImagePath = x.ImagePath
        //    }).First(x => x.Id == id);
    }
}