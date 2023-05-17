using AutoMapper;
using Placidusax.Data;
using Placidusax.Data.DBModels;
using Placidusax.Interfaces;
using Placidusax.Models.RequestModels;

namespace Placidusax.Implementations;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly PlacidusaxDbContext _dbContext;

    public UserService(IUnitOfWork unitOfWork, PlacidusaxDbContext dbContext)
    {
        _unitOfWork = unitOfWork;
        _dbContext = dbContext;
    }

    public async Task<User> CreateUser(UserRequestModel user)
    {
        var departments = await _unitOfWork.Repository<Department>().GetAllAsync();

        var department = departments.FirstOrDefault(x => x.Name == user.DepartmentName);

        if (department == null) throw new ArgumentNullException("Such department doesn't exist");

        var newUser = new User()
        {
            UserName = user.UserName,
            DateOfJoin = user.DateOfJoin,
            DepartmentName = department.Name,
            DepartmentId = department.Id,
            Department = department,
            PhotoFileName = user.PhotoFileName
        };

        var responseModel = await _unitOfWork.Repository<User>().AddAsync(newUser);

        await _unitOfWork.SaveChangesAsync();

        return newUser;
    }

    public async Task<User> GetUser(string id)
    {
        var existingUser = await _unitOfWork.Repository<User>().GetAsync(id);

        if (existingUser == null || existingUser.isDeleted == true) throw new ArgumentNullException("Such user doesn't exists");

        return existingUser;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var existingUsers = await _unitOfWork.Repository<User>().GetAllAsync();

        return existingUsers.Where(x => x.isDeleted != true);
    }

    public async Task<User> UpdateUser(UserUpdateRequestModel user)
    {
        var existingUser = await _unitOfWork.Repository<User>().GetAsync(user.Id);

        if (existingUser == null) throw new ArgumentNullException("Such user doesn't exists");

        existingUser.UserName = user.UserName;
        existingUser.DateOfJoin = user.DateOfJoin;
        existingUser.DepartmentName = user.DepartmentName;
        existingUser.PhotoFileName = user.PhotoFileName;
        var newDepartment = _dbContext.Departments.Where(x => x.Name == user.DepartmentName).FirstOrDefault();
        existingUser.Department = newDepartment;
        existingUser.DepartmentId = newDepartment.Id;

        _unitOfWork.Repository<User>().Update(existingUser);
        await _unitOfWork.SaveChangesAsync();

        return existingUser;
    }

    public async Task DeleteUser(string id)
    {
        var existingUser = await _unitOfWork.Repository<User>().GetAsync(id);

        if (existingUser == null) throw new ArgumentNullException("Such user doesn't exists");

        existingUser.isDeleted = true;

        await _unitOfWork.SaveChangesAsync();
    }
}
