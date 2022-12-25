namespace Petrochemical.ApplicationContracts.ArticleCategory;

public interface IArticleCategoryApplication
{
    void Create(CreateArticleCategory command);
    void Edit(EditArticleCategory command);
    void Remove(long id);
    void Restore(long id);
}