using API.DTOs;
using API.Entities;
using API.Helpers;


namespace API.Interfaces;

public interface IUserRepository
{
    Task<AppUser?> GetUserByIdAsync(int id);
    Task<AppUser?> GetUserByUsernameAsync(string username);
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<bool> SaveAllAsync();
    void Update(AppUser user);

    Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
    Task<MemberDto?> GetMemberAsync(string username);
}