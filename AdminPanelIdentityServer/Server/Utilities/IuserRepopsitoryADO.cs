using BlazorSignalR.Shared.Dtos;
using System.Threading.Tasks;

namespace blazorSource.Server.Repository
{
    public interface IuserRepopsitoryADO
    {
        Task<string> Create(UserDto user);
        Task<UserDto> GetUser(string username, string password);
        
    }


}
