using Placidusax.Data.DBModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Placidusax.Models.ResponseModels;

public class UserResponseModel
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public DateTime DateOfJoin { get; set; }

    public string DepartmentName { get; set; }

    public string PhotoFileName { get; set; }
}
