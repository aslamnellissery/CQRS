using CQRS.Core.Dto;
using MediatR;

namespace CQRSMediatR.Commads
{
    public class UpdateUserCommand : IRequest<ResponseDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
