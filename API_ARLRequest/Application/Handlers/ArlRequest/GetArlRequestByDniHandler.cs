﻿using API_ARLRequest.Application.DTOs;
using API_ARLRequest.Application.Queries.ArlRequest;
using API_ARLRequest.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API_ARLRequest.Application.Handlers.ArlRequest
{
    public class GetArlRequestByDniHandler : IRequestHandler<GetArlRequestByDniQuery, ArlRequestDto>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetArlRequestByDniHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ArlRequestDto> Handle(GetArlRequestByDniQuery request, CancellationToken cancellationToken)
        {
            var arlRequest = 
                await _dbContext.ArlRequests.FirstOrDefaultAsync
                (a => a.NumeroIdentificacion == request.NumeroIdentificacion);


            if (arlRequest != null)
            {
                return new ArlRequestDto
                {
                    IdSolicitudArl = arlRequest.IdSolicitudArl,
                    NumeroIdentificacion = arlRequest.NumeroIdentificacion,
                    TipoIdentificacion = arlRequest.TipoIdentificacion,
                    NombreEstudiante = arlRequest.NombreEstudiante,
                    EmailEstudiante = arlRequest.EmailEstudiante,
                    ModalidadPractica = arlRequest.ModalidadPractica,
                    PeriodoAcademico = arlRequest.PeriodoAcademico,
                    CapaOcho = arlRequest.CapaOcho,
                    DocumentoIdentidadFile = arlRequest.DocumentoIdentidadFile,
                    ProgramaAcademico = arlRequest.ProgramaAcademico,
                    TipoPractica = arlRequest.TipoPractica,
                    RutFile = arlRequest.RutFile,
                    NombreEmprendimiento = arlRequest.NombreEmprendimiento,
                    NitEmprendimiento = arlRequest.NitEmprendimiento,
                    CamaraComercioFile = arlRequest.CamaraComercioFile,
                    FechaNacimiento = arlRequest.FechaNacimiento,
                    EpsEstudiante = arlRequest.EpsEstudiante,
                    DocumentoEpsFile = arlRequest.DocumentoEpsFile,
                    NumeroTelEstudiante = arlRequest.NumeroTelEstudiante,
                    CorreoInstitucional = arlRequest.CorreoInstitucional,
                    NombreEmpresaPracticas = arlRequest.NombreEmpresaPracticas,
                    NitEmpresaPracticas = arlRequest.NitEmpresaPracticas,
                    RiesgoEstudiante = arlRequest.RiesgoEstudiante,
                    NombrePersonaACargoPractica = arlRequest.NombrePersonaACargoPractica,
                    TelefonoPersonasACargo = arlRequest.TelefonoPersonasACargo,
                    EmailPersonaACargoPractica = arlRequest.EmailPersonaACargoPractica,
                    FechaInicioPractica = arlRequest.FechaInicioPractica,
                    FechaTerminacionPractica = arlRequest.FechaTerminacionPractica,
                    ActaInicioPractica = arlRequest.ActaInicioPractica,
                    Regional = arlRequest.Regional,
                    Seleccion = arlRequest.Seleccion,
                    JornadaEstablecida = arlRequest.JornadaEstablecida,
                    ModoPractica = arlRequest.ModoPractica,
                    ZonaResidencial = arlRequest.ZonaResidencial,
                    FechaSolicitud = arlRequest.FechaSolicitud,
                    EstadoSolicitud = arlRequest.EstadoSolicitud,
                    Aprobo = arlRequest.Aprobo,
                    NombreAprobador = arlRequest.NombreAprobador,
                    MotivoAprobacion = arlRequest.MotivoAprobacion,
                    Archivos = arlRequest.Archivos.Select(file => new ArlFileDto
                    {
                        IdDocumentoARL = file.IdDocumentoARL,
                        NombreArchivo = file.NombreArchivo,
                        ReferenciaArchivo = file.ReferenciaArchivo
                    }).ToList()
                };
            }
            return null;
        }
    }
}