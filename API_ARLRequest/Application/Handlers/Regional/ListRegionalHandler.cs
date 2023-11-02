using API_ARLRequest.Application.DTOs;
using API_ARLRequest.Application.Queries.ArlRequest;
using API_ARLRequest.Application.Queries.Regional;
using API_ARLRequest.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API_ARLRequest.Application.Handlers.Regional
{
    public class ListRegionalHandler : IRequestHandler<ListRegionalesQuery, IEnumerable<RegionalDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListRegionalHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RegionalDto>> Handle(ListRegionalesQuery request, CancellationToken cancellationToken)
        {
            /*var regionales = _dbContext.Regionales
                .Where(r => r.Municipio.Contains(request.Filtro)).ToList();*/

            var regionales = await _dbContext.Regionales
                .Where(r => r.Municipio.Contains(request.Filtro))
                .Select(regional => new RegionalDto
                {
                    Municipio = regional.Municipio
                })
                .ToListAsync(cancellationToken);

            return regionales;
        }
    }
}
