using Placidusax.Data.DBModels;
using Placidusax.Models.RequestModels;

namespace Placidusax.Interfaces;

public interface IDepartmentService
{
    Task<Department> CreateDepartment(DepartmentRequestModel department);
    Task<Department> GetDepartment(string id);
    Task<IEnumerable<Department>> GetAllDepartments();
    Task<Department> UpdateDepartment(Department department);
    Task DeleteDepartment(string id);
}
