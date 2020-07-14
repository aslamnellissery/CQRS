using CQRS.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetUsers();
        Task<ResponseDto> AddUser(UserDto userDto);
        Task<ResponseDto> UpdateUser(UserDto userDto);
        Task<ResponseDto> DeleteUser(int userId);
    }
}
