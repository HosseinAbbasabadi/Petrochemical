using _0_Framework.Application;

namespace Petrochemical.ApplicationContracts.ArticleCategory;

public interface IArticleCategoryQuery : IQuery
{
    List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
    ArticleCategoryOps GetForEdit(long id);
}