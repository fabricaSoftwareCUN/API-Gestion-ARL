using MediatR;

namespace API_ARLRequest.Application.Commands.ArlRequest
{
    public record DeleteArlRequestCommand(int ArlRequestId) : IRequest<bool>;


}
