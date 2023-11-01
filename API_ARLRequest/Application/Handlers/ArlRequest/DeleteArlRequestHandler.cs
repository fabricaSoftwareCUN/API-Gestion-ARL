using API_ARLRequest.Application.Commands.ArlRequest;
using API_ARLRequest.Application.DTOs;
using API_ARLRequest.Infraestructure.Data;
using MediatR;

namespace API_ARLRequest.Application.Handlers.ArlRequest
{
    public class DeleteArlRequestHandler : IRequestHandler<DeleteArlRequestCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteArlRequestHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }   

        public async Task<bool> Handle(DeleteArlRequestCommand request, CancellationToken cancellationToken)
        {
            var arlRequest = await _dbContext.ArlRequests.FindAsync(
                new object[] { request.ArlRequestId }, cancellationToken);

            if(arlRequest != null)
            {
                _dbContext.ArlRequests.Remove(arlRequest);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;

        }
    }
}
