using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Placidusax.Data.DBModels;

public class Department
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public string Id { get; set; }

    public string Name { get; set; }

    [DefaultValue(false)]
    public bool IsDeleted { get; set; }
}
