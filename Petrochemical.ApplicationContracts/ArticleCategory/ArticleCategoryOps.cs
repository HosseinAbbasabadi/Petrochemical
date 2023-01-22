using System.ComponentModel.DataAnnotations;

namespace Petrochemical.ApplicationContracts.ArticleCategory;

public class ArticleCategoryOps
{
    public long Id { get; set; }

    [MaxLength(250, ErrorMessage = "Max Length For This Field Is 250.")]
    [Required(ErrorMessage = "This Field Is Required.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "This Field Is Required.")]
    public string ImagePath { get; set; }
}