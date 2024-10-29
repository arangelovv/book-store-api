using book_store_api.Models;

namespace book_store_api.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<UserModel>> GetAllAsync();
    Task<UserModel> GetUserByIdAsync(int id);
    Task<UserModel> CreateUserAsync(UserModel user);
    Task<UserModel> UpdateUserAsync(UserModel user);
    Task DeleteUserAsync(int id);
    
    
    
    
}