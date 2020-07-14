using CQRS.Core.Dto;
using CQRS.Core.Entities;
using CQRS.Core.Interfaces;
using CQRS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;
        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task<ResponseDto> AddUser(UserDto userDto)
        {
            var result = new ResponseDto();
            try
            {
                _userContext.User.Add(new User()
                {
                    Email = userDto.Email,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName
                });

                await _userContext.SaveChangesAsync();

                result.Status = "Sucesss";
            }
            catch (System.Exception)
            {

                result.Status = "Failed";
            }

            return result;
        }

        public async Task<ResponseDto> DeleteUser(int userId)
        {
            var result = new ResponseDto();
            try
            {
                var user = await _userContext.User.FirstOrDefaultAsync(x => x.Id == userId);
                _userContext.Remove(user);
                await _userContext.SaveChangesAsync();

                result.Status = "Sucesss";
            }
            catch (System.Exception)
            {

                result.Status = "Failed";
            }

            return result;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var users = new List<UserDto>();
            try
            {

                var data = await _userContext.User.ToListAsync();

                foreach (var item in data)
                {
                    var result = new UserDto()
                    {
                        Email = item.Email,
                        FirstName = item.FirstName,
                        Id = item.Id,
                        LastName = item.LastName
                    };

                    users.Add(result);

                }
            }
            catch (System.Exception ex)
            {


            }
            return users;
        }

        public async Task<ResponseDto> UpdateUser(UserDto userDto)
        {
            var result = new ResponseDto();
            try
            {
                var user = await _userContext.User.FirstOrDefaultAsync(x => x.Id == userDto.Id);
                user.Email = userDto.Email;
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;

                await _userContext.SaveChangesAsync();

                result.Status = "Sucesss";
            }
            catch (System.Exception)
            {

                result.Status = "Failed";
            }

            return result;
        }
    }
}
