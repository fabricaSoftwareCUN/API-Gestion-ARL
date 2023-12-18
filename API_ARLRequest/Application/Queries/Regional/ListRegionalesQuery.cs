using API_ARLRequest.Application.DTOs;
using API_ARLRequest.Domain;
using MediatR;

namespace API_ARLRequest.Application.Queries.Regional
{
    public record ListRegionalesQuery(string Filtro) : IRequest<IEnumerable<RegionalDto>>;
}
