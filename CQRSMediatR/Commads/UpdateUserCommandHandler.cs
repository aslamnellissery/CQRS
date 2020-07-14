using CQRS.Core.Dto;
using CQRS.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatR.Commads
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseDto>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userReq = new UserDto()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                Id = request.Id,
                LastName = request.LastName

            };

            var result = await _userRepository.UpdateUser(userReq);
            return result;
        }
    }
}
