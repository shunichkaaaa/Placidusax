using Placidusax.Data.DBModels;
using Placidusax.Models.RequestModels;

namespace Placidusax.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(UserRequestModel user);
        Task<User> GetUser(string id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> UpdateUser(UserUpdateRequestModel user);
        Task DeleteUser(string id);

    }
}
