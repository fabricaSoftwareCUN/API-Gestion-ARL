using API_ARLRequest.Infraestructure.Data;
using API_ARLRequest.Infraestructure.Security.DTOs;
using API_ARLRequest.Infraestructure.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ARLRequest.Infraestructure.Security.Services
{
    public class ArlUserService
    {
        private readonly ApplicationDbContext _context;
        public ArlUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> GetUserByIdAsync(int IdUser)
        {
            var user = await _context.Users.FindAsync(IdUser);
            if (user == null)
            {
                throw new InvalidOperationException("Usuario no encontrado.");
            }

            var userDTO = new UserDTO
            {
                Email = user.Email,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Rol = user.Rol,

            };

            return userDTO;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            var userDTOs = users.Select(user => new UserDTO
            {
                Email = user.Email,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Rol = user.Rol,
            }).ToList();
            return userDTOs;
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            //var existingPendingRequest = await _context.ArlRequests
            //.FirstOrDefaultAsync(a => a.NumeroIdentificacion == request.NumeroIdentificacion && a.EstadoSolicitud == "Pendiente");


            // TODO: AGREGAR VALIDACIONES Y COMPLETAR CRUD 

            var newUser = new User
            {
                Email = userDTO.Email,
                Nombre = userDTO.Nombre,
                Apellido = userDTO.Apellido,
                Rol = userDTO.Rol,
                // ... otros atributos
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Email = newUser.Email,
                Nombre = newUser.Nombre,
                Apellido = newUser.Apellido,
                Rol = newUser.Rol,
            };
        }


        public async Task<UserDTO> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = await _context.Users.FindAsync(updateUserDto.IdUser);

            if (user == null)
            {
                throw new InvalidOperationException("Usuario no encontrado.");
            }

            user.Rol = updateUserDto.Rol;


            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Email = user.Email,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Rol = user.Rol
            };
        }

        public async Task<bool> DeleteUserAsync(int idUser)
        {
            var user = await _context.Users.FindAsync(idUser);

            if (user == null)
            {
                throw new InvalidOperationException("Usuario no encontrado.");
            }

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
