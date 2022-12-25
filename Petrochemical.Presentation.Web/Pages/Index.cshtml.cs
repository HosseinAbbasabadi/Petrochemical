using Microsoft.AspNetCore.Mvc.RazorPages;
using Petrochemical.ApplicationContracts.ArticleCategory;

namespace Petrochemical.Presentation.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IArticleCategoryApplication _articleCategoryApplication;

    public IndexModel(IArticleCategoryApplication articleCategoryApplication)
    {
        _articleCategoryApplication = articleCategoryApplication;
    }

    public void OnGet()
    {
        //_articleCategoryApplication.Create();
    }
}