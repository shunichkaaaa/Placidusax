using AutoMapper;
using Placidusax.Data;
using Placidusax.Data.DBModels;
using Placidusax.Interfaces;
using Placidusax.Models.RequestModels;

namespace Placidusax.Implementations;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly PlacidusaxDbContext _placidusaxDbContext;

    public DepartmentService(IUnitOfWork unitOfWork, PlacidusaxDbContext placidusaxDbContext)
    {
        _unitOfWork = unitOfWork;
        _placidusaxDbContext = placidusaxDbContext;
    }

    public async Task<Department> CreateDepartment(DepartmentRequestModel department)
    {
        var existingDepartment = _placidusaxDbContext.Departments.Where(x => x.Name == department.Name).FirstOrDefault();

        if (existingDepartment != null || existingDepartment.IsDeleted) throw new ArgumentException("Department with such name already exists");

        var newDepartment = new Department();

        newDepartment.Name = department.Name;

        await _unitOfWork.Repository<Department>().AddAsync(newDepartment);

        await _unitOfWork.SaveChangesAsync();

        return newDepartment;
    }
    public async Task<Department> GetDepartment(string id)
    {
        var existingDepartment = await _unitOfWork.Repository<Department>().GetAsync(id);

        if (existingDepartment == null || existingDepartment.IsDeleted == true) throw new ArgumentNullException("Such department doesn't exist or was deleted");

        return existingDepartment;
    }

    public async Task<IEnumerable<Department>> GetAllDepartments()
    {
        var existingDepartments = await _unitOfWork.Repository<Department>().GetAllAsync();

        return existingDepartments.Where(x => x.IsDeleted != true);
    }

    public async Task<Department> UpdateDepartment(Department department)
    {
        var existingDepartment = await _unitOfWork.Repository<Department>().GetAsync(department.Id);

        if (existingDepartment == null) throw new ArgumentNullException("Such department doesn't exist");

        existingDepartment.Name = department.Name;

        _unitOfWork.Repository<Department>().Update(existingDepartment);
        await _unitOfWork.SaveChangesAsync();

        var users = await _unitOfWork.Repository<User>().GetAllAsync();

        foreach (var user in users)
        {
            user.Department = existingDepartment;
            user.DepartmentId = department.Id;
            user.DepartmentName = department.Name;

            _unitOfWork.Repository<User>().Update(user);
            await _unitOfWork.SaveChangesAsync();
        }

        return department;
    }

    public async Task DeleteDepartment(string id)
    {
        var existingDepartment = await _unitOfWork.Repository<Department>().GetAsync(id);

        if (existingDepartment == null) throw new ArgumentNullException("Such department doesn't exist");

        existingDepartment.IsDeleted = true;

        await _unitOfWork.SaveChangesAsync();
    }
}
