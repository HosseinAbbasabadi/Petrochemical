namespace Petrochemical.Domain.ArticleCategoryAgg;

public class ArticleCategory
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string ImagePath { get; private set; }
    public bool IsRemoved { get; private set; }

    public ArticleCategory(string name, string imagePath)
    {
        // Create Business
        SetProperties(name, imagePath);
        IsRemoved = false;
    }

    public void Edit(string name, string imagePath)
    {
        // Edit Business
        SetProperties(name, imagePath);
    }

    public void SetProperties(string name, string imagePath)
    {
        GuardAgainstNullName(name);
        Name = name;

        if (!string.IsNullOrWhiteSpace(imagePath))
            ImagePath = imagePath;
    }

    private static void GuardAgainstNullName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new NullReferenceException();
    }

    public void Removed()
    {
        IsRemoved = true;
    }

    public void Restore()
    {
        IsRemoved = false;
    }
}