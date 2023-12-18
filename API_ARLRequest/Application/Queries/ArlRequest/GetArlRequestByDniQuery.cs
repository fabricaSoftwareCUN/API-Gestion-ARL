using API_ARLRequest.Application.DTOs;
using MediatR;

namespace API_ARLRequest.Application.Queries.ArlRequest
{
    public record GetArlRequestByDniQuery(string NumeroIdentificacion) : IRequest<IEnumerable<ArlRequestDto>>
    {
    }
}
