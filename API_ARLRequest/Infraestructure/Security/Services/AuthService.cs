using API_ARLRequest.Infraestructure.Data;
using API_ARLRequest.Infraestructure.Security.DTOs;
using API_ARLRequest.Infraestructure.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ARLRequest.Infraestructure.Security.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUser(LoginUserDTO loginUserDTO)
        {
            return await _context.Users
                .SingleOrDefaultAsync(user => user.Email == loginUserDTO.Email);
        }


    }
}
