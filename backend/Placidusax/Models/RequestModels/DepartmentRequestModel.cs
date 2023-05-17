using System.ComponentModel.DataAnnotations;

namespace Placidusax.Models.RequestModels;

public class DepartmentRequestModel
{
    [Required]
    public string Name { get; set; }
}
