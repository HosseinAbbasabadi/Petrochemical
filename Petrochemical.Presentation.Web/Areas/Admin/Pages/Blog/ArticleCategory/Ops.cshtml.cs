using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Petrochemical.ApplicationContracts.ArticleCategory;

namespace Petrochemical.Presentation.Web.Areas.Admin.Pages.Blog.ArticleCategory;

public class OpsModel : PageModel
{
    [BindProperty] public ArticleCategoryOps Command { get; set; }
    private readonly IArticleCategoryQuery _articleCategoryQuery;
    private readonly IArticleCategoryApplication _articleCategoryApplication;

    public OpsModel(IArticleCategoryApplication articleCategoryApplication, IArticleCategoryQuery articleCategoryQuery)
    {
        _articleCategoryApplication = articleCategoryApplication;
        _articleCategoryQuery = articleCategoryQuery;
    }

    public void OnGet(long id)
    {
        if (id > 0) Command = _articleCategoryQuery.GetForEdit(id);
    }

    public IActionResult OnPost()
    {
        var result = new OperationResult();
        if (Command.Id > 0)
            _articleCategoryApplication.Edit(Command);
        else
            result = _articleCategoryApplication.Create(Command);

        if (!result.IsSucceeded)
        {
            TempData["errorMessage"] = result.Message;
            return Page();
        }

        TempData["successMessage"] = result.Message;
        return RedirectToPage("./Index");
    }
}