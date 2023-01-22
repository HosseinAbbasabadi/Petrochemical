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
        if (ModelState.IsValid)
        {
            if (Command.Id > 0)
                _articleCategoryApplication.Edit(Command);
            else
                _articleCategoryApplication.Create(Command);

            TempData["successMessage"] = "Operation Done Successfully.";
            return RedirectToPage("./Index");
        }

        TempData["errorMessage"] = "Error! Please try again.";
        return Page();
    }
}