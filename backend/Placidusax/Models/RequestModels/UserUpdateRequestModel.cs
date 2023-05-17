namespace Placidusax.Models.RequestModels;

public class UserUpdateRequestModel
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string DepartmentName { get; set; }
    public string DateOfJoin { get; set; }
    public string PhotoFileName { get; set; }
}
