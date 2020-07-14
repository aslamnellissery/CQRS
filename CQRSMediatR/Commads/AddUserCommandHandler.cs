using CQRS.Core.Dto;
using CQRS.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatR.Commads
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, ResponseDto>
    {
        private readonly IUserRepository _userRepository;
        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var userReq = new UserDto()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                Id = request.Id,
                LastName = request.LastName

            };

            var result = await _userRepository.AddUser(userReq);
            return result;
        }
    }
}
