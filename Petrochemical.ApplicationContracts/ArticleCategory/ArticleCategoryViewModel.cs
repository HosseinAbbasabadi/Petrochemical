namespace Petrochemical.ApplicationContracts.ArticleCategory;

public class ArticleCategoryViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public bool IsRemoved { get; set; }
}