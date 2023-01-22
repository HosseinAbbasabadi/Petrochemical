namespace Petrochemical.ApplicationContracts.ArticleCategory;

public interface IArticleCategoryApplication
{
    void Create(ArticleCategoryOps command);
    void Edit(ArticleCategoryOps command);
    void Remove(long id);
    void Restore(long id);
}