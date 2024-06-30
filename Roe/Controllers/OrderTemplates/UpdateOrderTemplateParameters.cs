using System.ComponentModel.DataAnnotations;

namespace Roe.Controllers.OrderTemplates;

public class UpdateOrderTemplateParameters
{
    [Required, MinLength(3)]
    public string Title { get; set; } = null!;

}
