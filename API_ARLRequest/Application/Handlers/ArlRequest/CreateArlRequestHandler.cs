using API_ARLRequest.Application.Commands.ArlRequest;
using API_ARLRequest.Application.DTOs;
using API_ARLRequest.Domain;
using API_ARLRequest.Infraestructure.AWS.AmazonS3.Services;
using API_ARLRequest.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API_ARLRequest.Application.Handlers.ArlRequest
{
    public class CreateArlRequestHandler : IRequestHandler<CreateArlRequestCommand, ArlRequestDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly AmazonS3 _amazonS3;
        public CreateArlRequestHandler(ApplicationDbContext dbContext, AmazonS3 amazonS3)
        {
            _dbContext = dbContext;
            _amazonS3 = amazonS3;
        }

        public async Task<ArlRequestDto> Handle(CreateArlRequestCommand request, CancellationToken cancellationToken)
        {
            var existingArlRequest = 
                await _dbContext.ArlRequests.FirstOrDefaultAsync
                (a => a.NumeroIdentificacion == request.NumeroIdentificacion);

            /*if (existingArlRequest != null)
            {
                // validación y lanzar una excepción personalizada si ya existe un registro.
                throw new Exception("Ya existe un registro con el mismo número de identificación.");
            }*/

            var urls = await _amazonS3.UploadFilesToS3Async(request.Archivos, request.NumeroIdentificacion);
            
            var arlRequest = new Domain.ArlRequest()
            {
                NumeroIdentificacion = request.NumeroIdentificacion,
                TipoIdentificacion = request.TipoIdentificacion,
                NombreEstudiante = request.NombreEstudiante,
                EmailEstudiante = request.EmailEstudiante,
                ModalidadPractica = request.ModalidadPractica,
                PeriodoAcademico = request.PeriodoAcademico,
                CapaOcho = request.CapaOcho,
                DocumentoIdentidadFile = request.DocumentoIdentidadFile,
                ProgramaAcademico = request.ProgramaAcademico,
                TipoPractica = request.TipoPractica,
                RutFile = request.RutFile,
                NombreEmprendimiento = request.NombreEmprendimiento,
                NitEmprendimiento = request.NitEmprendimiento,
                CamaraComercioFile = request.CamaraComercioFile,
                FechaNacimiento = request.FechaNacimiento,
                EpsEstudiante = request.EpsEstudiante,
                DocumentoEpsFile = request.DocumentoEpsFile,
                NumeroTelEstudiante = request.NumeroTelEstudiante,
                CorreoInstitucional = request.CorreoInstitucional,
                NombreEmpresaPracticas = request.NombreEmpresaPracticas,
                NitEmpresaPracticas = request.NitEmpresaPracticas,
                RiesgoEstudiante = request.RiesgoEstudiante,
                NombrePersonaACargoPractica = request.NombrePersonaACargoPractica,
                TelefonoPersonasACargo = request.TelefonoPersonasACargo,
                EmailPersonaACargoPractica = request.EmailPersonaACargoPractica,
                FechaInicioPractica = request.FechaInicioPractica,
                FechaTerminacionPractica = request.FechaTerminacionPractica,
                ActaInicioPractica = request.ActaInicioPractica,
                Regional = request.Regional,
                Seleccion = request.Seleccion,
                JornadaEstablecida = request.JornadaEstablecida,
                ModoPractica = request.ModoPractica,
                ZonaResidencial = request.ZonaResidencial,
                FechaSolicitud = request.FechaSolicitud,
                EstadoSolicitud = request.EstadoSolicitud,
                Aprobo = request.Aprobo,
                NombreAprobador = request.NombreAprobador,
                MotivoAprobacion = request.MotivoAprobacion,
                Archivos = request.Archivos.Select((f, i) => new ArlFile
                {
                    NombreArchivo = f.NombreArchivo,
                    ReferenciaArchivo = urls[i]
                }).ToList()
            };

            _dbContext.ArlRequests.Add(arlRequest);
            await _dbContext.SaveChangesAsync(cancellationToken);
           
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
                Aprobo = arlRequest.Aprobo,
                MotivoAprobacion = arlRequest.MotivoAprobacion,
                Archivos = arlRequest.Archivos.Select(file => new ArlFileDto
                {
                    IdDocumentoARL = file.IdDocumentoARL,
                    NombreArchivo = file.NombreArchivo,
                    ReferenciaArchivo = file.ReferenciaArchivo
                }).ToList()
            };
        }
    }
}
