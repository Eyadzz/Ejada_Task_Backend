using Domain.UserModule;

namespace Application.Contracts.Persistence.Repositories;

public interface IUserRepository : IAsyncRepository<User>
{
    Task<User?> GetUserByEmail(string email);
    Task<bool> EmailExists(string email);
    Task<bool> PhoneNumberExists(string phoneNumber);
    Task<ICollection<User>>? GetUsersByRole(string roleName);
    Task<User?> GetUserWithRole(int userId);
    Task<ICollection<Role>> GetAllRoles();
}
