namespace Petrochemical.ApplicationContracts.ArticleCategory;

public interface IArticleCategoryQuery
{
    List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
    ArticleCategoryOps GetForEdit(long id);
}