using book_store_api.Models;
using book_store_api.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace book_store_api.Controller;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;        
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllAsync();

        var response = users.Adapt<List<UserDTO>>();
        
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        
        var response = user.Adapt<UserDTO>();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] UserDTO userDto)
    {
        var user = userDto.Adapt<UserModel>();
        
        var createdUser = await _userRepository.CreateUserAsync(user);

        var response = createdUser.Adapt<UserDTO>();

        return Ok(response);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDto)
    {
        
        var updatedUser = userDto.Adapt<UserModel>();
        updatedUser.Id = id;
        
        await _userRepository.UpdateUserAsync(updatedUser);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userRepository.DeleteUserAsync(id);
        
        return NoContent();
    }
}