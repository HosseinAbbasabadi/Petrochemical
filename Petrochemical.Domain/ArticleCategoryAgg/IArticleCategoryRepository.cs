namespace Petrochemical.Domain.ArticleCategoryAgg;

public interface IArticleCategoryRepository
{
    void Create(ArticleCategory entity);
    List<ArticleCategory> GetAll();
    ArticleCategory GetById(long id);
    void Commit();
}