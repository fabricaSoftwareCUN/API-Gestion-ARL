using API_ARLRequest.Application.Commands.ArlRequest;
using API_ARLRequest.Application.DTOs;
using API_ARLRequest.Infraestructure.Data;
using MediatR;

namespace API_ARLRequest.Application.Handlers.ArlRequest
{
    public class UpdateArlRequestHandler : IRequestHandler<UpdateArlRequestCommand, ArlRequestDto>
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateArlRequestHandler(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task<ArlRequestDto> Handle(UpdateArlRequestCommand request, CancellationToken cancellationToken)
        {
            var arlRequest = await _dbContext.ArlRequests.FindAsync(
                new object[] { request.IdSolicitudArl }, cancellationToken);

            if (arlRequest == null)
            {
                throw new InvalidOperationException("No es una solicitud valida para resolver.");
            }

            DateTime dateTime = DateTime.Now;
            var fechaFormateada = dateTime.ToString();

            // Actualizar el registro existente con los campos recibidos
            arlRequest.EstadoSolicitud = request.EstadoSolicitud;
            arlRequest.NombreAprobador = request.NombreAprobador;
            arlRequest.MotivoAprobacion = request.MotivoAprobacion;
            arlRequest.FechaRespuestaSolicitud = fechaFormateada;


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
                //DocumentoIdentidadFile = arlRequest.DocumentoIdentidadFile,
                ProgramaAcademico = arlRequest.ProgramaAcademico,
                TipoPractica = arlRequest.TipoPractica,
                //RutFile = arlRequest.RutFile,
                NombreEmprendimiento = arlRequest.NombreEmprendimiento,
                NitEmprendimiento = arlRequest.NitEmprendimiento,
                //CamaraComercioFile = arlRequest.CamaraComercioFile,
                FechaNacimiento = arlRequest.FechaNacimiento,
                EpsEstudiante = arlRequest.EpsEstudiante,
                //DocumentoEpsFile = arlRequest.DocumentoEpsFile,
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
                //ActaInicioPractica = arlRequest.ActaInicioPractica,
                Regional = arlRequest.Regional,
                Seleccion = arlRequest.Seleccion,
                JornadaEstablecida = arlRequest.JornadaEstablecida,
                ModoPractica = arlRequest.ModoPractica,
                ZonaResidencial = arlRequest.ZonaResidencial,
                FechaSolicitud = arlRequest.FechaSolicitud,
                EstadoSolicitud = arlRequest.EstadoSolicitud,
                //Aprobo = arlRequest.Aprobo,
                NombreAprobador = arlRequest.NombreAprobador,
                MotivoAprobacion = arlRequest.MotivoAprobacion,
                FechaRespuestaSolicitud = arlRequest.FechaRespuestaSolicitud,
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
