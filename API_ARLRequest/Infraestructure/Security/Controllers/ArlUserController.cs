using API_ARLRequest.Infraestructure.Security.DTOs;
using API_ARLRequest.Infraestructure.Security.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace API_ARLRequest.Infraestructure.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArlUserController : ControllerBase
    {
        private readonly ArlUserService _arlUserService;
        public ArlUserController(ArlUserService arlUserService)
        {
            _arlUserService = arlUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _arlUserService.GetUsersAsync();
            if (users == null)
            {
                return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = "No se encontraron usuarios en la Base de Datos." });
            }

            return Ok(new { Status = true, Code = HttpStatusCode.OK, users });
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDTO>> GetUser(int userId)
        {

            try
            {
                var user = await _arlUserService.GetUserByIdAsync(userId);

                if (user == null)
                {
                    return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = "No se encontraron usuarios en la Base de Datos." });
                }
                return Ok(new { Status = true, Code = HttpStatusCode.OK, user });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = true, Code = HttpStatusCode.BadRequest, Message = ex.Message });
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDTO)
        {

            if (userDTO.Email == null || userDTO.Email == "" || userDTO.Rol == null || userDTO.Rol == "")
            {
                return BadRequest("Datos de usuario no válidos.");
            }

            try
            {
                var createdUser = await _arlUserService.CreateUserAsync(userDTO);
                //var action = CreatedAtAction(nameof(GetUser), new { IdUser = createdUser.IdUser }, createdUser);

                return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = "Usuario creado exitosamente.." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = true, Code = HttpStatusCode.BadRequest, Message = ex.Message });
            }
        }

        [HttpPut("UpdateRol")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                if (updateUserDto == null)
                {
                    return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"Usuario no encontrado con ID {updateUserDto.IdUser}" });
                }

                var updatedUser = await _arlUserService.UpdateUserAsync(updateUserDto);
                return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = "Rol de usuario Actualizado", updatedUser });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = true, Code = HttpStatusCode.BadRequest, Message = ex.Message });
            }

        }


        [HttpDelete("{IdUser}")]
        public async Task<IActionResult> DeleteCandidate(int IdUser)
        {
            try
            {
                var deletedUser = await _arlUserService.DeleteUserAsync(IdUser);
                if (!deletedUser)
                {
                    return BadRequest(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"Usuario con ID '{IdUser}' no encontrado o error de base de datos." });
                }
                return Ok(new { Status = true, Code = HttpStatusCode.NoContent, Message = "Usuario eliminado exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = true, Code = HttpStatusCode.BadRequest, Message = ex.Message });
            }
        }

    }
}
