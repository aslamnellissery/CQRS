using CQRS.Core.Dto;
using MediatR;

namespace CQRSMediatR.Commads
{
    public class DeleteUserCommand : IRequest<ResponseDto>
    {
        public int Id { get; set; }
    }
}
