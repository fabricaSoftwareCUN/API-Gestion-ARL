﻿using API_ARLRequest.Application.Commands.ArlRequest;
using API_ARLRequest.Application.DTOs;
using API_ARLRequest.Application.Queries.ArlRequest;
using API_ARLRequest.Domain;
using API_ARLRequest.Infraestructure.AWS.AmazonS3.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Net;

namespace API_ARLRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArlRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AmazonS3 _amazonS3;
        public ArlRequestController(IMediator mediator, AmazonS3 amazonS3)
        {
            _mediator = mediator;
            _amazonS3 = amazonS3;
        }


        #region GetCommands

        [HttpGet]
        public async Task<IActionResult> GetAllArlRequests()
        {
            
            var arlRequests = await _mediator.Send(new ListArlRequestsQuery());
            if(arlRequests == null || arlRequests.Count() <= 0)
            {
                return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = "No se encontraron solicitudes ARL en la base de datos." });
            }
            return Ok(new { Status = true, Code = HttpStatusCode.OK, arlRequests });

        }

        [HttpGet("Id/{IdSolicitudArl}")]
        public async Task<IActionResult> GetArlRequestById(int IdSolicitudArl)
        {
            IdSolicitudArl = IdSolicitudArl < 0 ? (IdSolicitudArl * (-1)) : IdSolicitudArl;
            var arlRequest = await _mediator.Send(new GetArlRequestByIdQuery(IdSolicitudArl));
            if(arlRequest == null)
            {
                return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No se encontró ninguna solicitud de ARL con ID: {IdSolicitudArl}." });
            }
            return Ok(new { Status = true, Code = HttpStatusCode.OK, arlRequest });
        }

        [HttpGet("Dni/{NumeroIdentificacion}")]
        public async Task<IActionResult> GetArlRequestByDni(string NumeroIdentificacion)
        {
            var arlRequest = await _mediator.Send(new GetArlRequestByDniQuery(NumeroIdentificacion));
            if (arlRequest == null)
            {
                return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No se encontró ninguna solicitud de ARL con numero de documento: {NumeroIdentificacion}." });
            }
            return Ok(new { Status = true, Code = HttpStatusCode.OK, arlRequest });
        }

        #endregion

        #region PostCommands
        [HttpPost]
        public async Task<IActionResult> CreateArlRequest(CreateArlRequestCommand command)
        {

            try
            {
                var arlRequest = await _mediator.Send(command);
                var action = CreatedAtAction(nameof(GetArlRequestById), new { IdSolicitudArl = arlRequest.IdSolicitudArl }, arlRequest);

                //var urls = await _amazonS3.UploadFilesToS3Async(command.Archivos, arlRequest.NumeroIdentificacion);


                return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = "La solicitud de ARL se ha enviado exitosamente. ", arlRequest = action.Value});
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = true, Code = HttpStatusCode.BadRequest, Message = ex.Message });
            }

            
        }

        #endregion

        #region PutCommands

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateArlRequest(UpdateArlRequestCommand command)
        {
            try
            {
                var arlRequest = await _mediator.Send(command);
                if (arlRequest == null)
                {
                    return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No se encontró ninguna solicitud de ARL con ID {command.IdSolicitudArl}." });
                }
                return Ok(new { Status = true, Code = HttpStatusCode.OK, arlRequest });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = true, Code = HttpStatusCode.BadRequest, Message = ex.Message });
            }

        }


        #endregion

        #region DeleteCommands

        [HttpDelete("Delete/{IdSolicitudArl}")]
        public async Task<IActionResult> DeleteArlRequest(int IdSolicitudArl)
        {
            try
            {
                var existingResource = await _mediator.Send(new DeleteArlRequestCommand(IdSolicitudArl));
                if (!existingResource)
                {
                    return BadRequest(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No se encontró ninguna solicitud de ARL en la base de datos con el ID {IdSolicitudArl} ó puede ser un error de la base de datos." });
                }

                return Ok(new { Status = true, Code = HttpStatusCode.NoContent, Message = "Solicitud de ARL eliminada con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = true, Code = HttpStatusCode.BadRequest, Message = ex.Message });
            }
            
        }

        #endregion

    }
}