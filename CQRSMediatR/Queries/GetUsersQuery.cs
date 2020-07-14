using CQRS.Core.Dto;
using MediatR;
using System.Collections.Generic;

namespace CQRSMediatR.Quries
{
    public class GetUsersQuery : IRequest<List<UserDto>>
    {

    }
}
