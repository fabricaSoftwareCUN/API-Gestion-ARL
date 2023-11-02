using API_ARLRequest.Application.DTOs;
using API_ARLRequest.Domain;
using MediatR;

namespace API_ARLRequest.Application.Commands.ArlRequest
{
    public record UpdateArlRequestCommand
        (
        int IdSolicitudArl,
        string EstadoSolicitud,
        string NombreAprobador,
        string MotivoAprobacion
        )
        : IRequest<ArlRequestDto>;
    
}
