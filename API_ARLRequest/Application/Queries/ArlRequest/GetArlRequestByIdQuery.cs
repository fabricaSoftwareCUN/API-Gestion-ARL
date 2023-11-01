using API_ARLRequest.Application.DTOs;
using MediatR;

namespace API_ARLRequest.Application.Queries.ArlRequest
{
    public record GetArlRequestByIdQuery(int IdSolicitudArl) : IRequest<ArlRequestDto>;
}
