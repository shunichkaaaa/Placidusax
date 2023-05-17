using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Placidusax.Data.DBModels;
using Placidusax.Interfaces;
using Placidusax.Models.RequestModels;
using Placidusax.Models.ResponseModels;

namespace Placidusax.Controllers;

[ApiController]
[Route("api/employee")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;

    public UsersController(IUserService userService, IMapper mapper, IWebHostEnvironment environment)
    {
        _userService = userService;
        _mapper = mapper;
        _env = environment;
    }

    [HttpPost]
    public async Task<IActionResult> Add(UserRequestModel model)
    {
        var newUser = await _userService.CreateUser(model);

        var responseModel = _mapper.Map<UserResponseModel>(newUser);

        return Ok(responseModel);
    }

    [HttpGet("me")]
    public async Task<IActionResult> Get(string id)
    {
        var user = await _userService.GetUser(id);

        var resultUser = _mapper.Map<UserResponseModel>(user);

        return Ok(resultUser);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsers();

        var resultUsersList = new List<UserResponseModel>();

        foreach (var user in users)
        {
            resultUsersList.Add(_mapper.Map<UserResponseModel>(user));
        }

        return Ok(resultUsersList);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UserUpdateRequestModel user)
    {
        var updatedUser = await _userService.UpdateUser(user);

        var resultUser = _mapper.Map<UserResponseModel>(updatedUser);

        return Ok(resultUser);
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(string id)
    {
        await _userService.DeleteUser(id);

        return Ok("User was deleted");
    }

    [Route("SaveFile")]
    [HttpPost]
    public JsonResult SaveFile()
    {
        try
        {
            var httpRequest = Request.Form;
            var postedFile = httpRequest.Files[0];
            string filename = postedFile.FileName;
            var physicalPath = _env.ContentRootPath+ "/Photos/" + filename;

            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }

            return new JsonResult(filename);
        }
        catch (Exception)
        {
            return new JsonResult("anonymous.pnh");
        }
    }
}
