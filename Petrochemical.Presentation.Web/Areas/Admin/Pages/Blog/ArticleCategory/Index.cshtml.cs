using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Petrochemical.ApplicationContracts.ArticleCategory;

namespace Petrochemical.Presentation.Web.Areas.Admin.Pages.Blog.ArticleCategory;

public class IndexModel : PageModel
{
    public List<ArticleCategoryViewModel> List;
    public ArticleCategorySearchModel SearchModel;
    private readonly IArticleCategoryQuery _articleCategoryQuery;

    public IndexModel(IArticleCategoryQuery articleCategoryQuery)
    {
        _articleCategoryQuery = articleCategoryQuery;
    }

    public void OnGet(ArticleCategorySearchModel searchModel)
    {
        List = _articleCategoryQuery.Search(searchModel);
    }

    public IActionResult OnGetEdit(long id)
    {
        //var articleCategory = _articleCategoryQuery.GetForEdit(id);
        return RedirectToPage("./Ops", new { id });
    }
}