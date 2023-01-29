using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Petrochemical.Application;
using Petrochemical.ApplicationContracts.ArticleCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Petrochemical.Presentation.Web.Areas.Admin.Pages.Blog.ArticleCategory;

public class IndexModel : PageModel
{
    public List<ArticleCategoryViewModel> List;
    public ArticleCategorySearchModel SearchModel;

    [BindProperty] public ArticleCategoryOps CreateCommand { get; set; }
    private readonly IArticleCategoryQuery _articleCategoryQuery;
    private readonly IArticleCategoryApplication _articleCategoryApplication;

    public IndexModel(IArticleCategoryQuery articleCategoryQuery,
        IArticleCategoryApplication articleCategoryApplication)
    {
        _articleCategoryQuery = articleCategoryQuery;
        _articleCategoryApplication = articleCategoryApplication;
    }

    public void OnGet(ArticleCategorySearchModel searchModel)
    {
        List = _articleCategoryQuery.Search(searchModel);
    }

    public IActionResult OnGetList()
    {
        var list = _articleCategoryQuery.Search(new ArticleCategorySearchModel());
        return Partial("./List", list);
    }

    public IActionResult OnGetOperations(int id)
    {
        var command = new ArticleCategoryOps();

        if (id > 0)
            command = _articleCategoryQuery.GetForEdit(id);

        return Partial("./Ops", command);
    }

    //public IActionResult OnGetEdit(long id)
    //{
    //    //var articleCategory = _articleCategoryQuery.GetForEdit(id);
    //    return RedirectToPage("./Ops", new { id });
    //}

    public IActionResult OnPostOperations()
    {
        var result = CreateCommand.Id > 0
            ? _articleCategoryApplication.Edit(CreateCommand)
            : _articleCategoryApplication.Create(CreateCommand);

        return new JsonResult(result);
    }
}