using AutoMapper;
using Placidusax.Data.DBModels;
using Placidusax.Models.RequestModels;
using Placidusax.Models.ResponseModels;

namespace Placidusax.AutoMapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<UserRequestModel, User>();
        CreateMap<User, UserResponseModel>();
    }
}
