using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Placidusax.Data.DBModels;

public class User : IdentityUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public override string Id { get; set; }

    public string UserName { get; set; }

    public DateTime DateOfJoin { get; set; }

    public string DepartmentName { get; set; }

    public string? DepartmentId { get; set; }

    public string PhotoFileName { get; set; }

    [DefaultValue(false)]
    public bool isDeleted { get; set; }

    [ForeignKey("DepartmentId")]
    public virtual Department Department { get; set; }
}
