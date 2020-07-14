using CQRS.Core.Dto;
using CQRS.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatR.Commads
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResponseDto>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.DeleteUser(request.Id);
            return result;
        }
    }
}
