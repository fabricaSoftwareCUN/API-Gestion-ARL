using API_ARLRequest.Application.DTOs;
using API_ARLRequest.Domain;
using MediatR;

namespace API_ARLRequest.Application.Commands.ArlRequest
{
    public record CreateArlRequestCommand
        (
        string NumeroIdentificacion,
        string TipoIdentificacion,
        string NombreEstudiante,
        string EmailEstudiante,
        string ModalidadPractica,
        string PeriodoAcademico,
        bool CapaOcho,
        string ProgramaAcademico,
        string TipoPractica,
        string NombreEmprendimiento,
        string NitEmprendimiento,
        string FechaNacimiento,
        string EpsEstudiante,
        string NumeroTelEstudiante,
        string CorreoInstitucional,
        string NombreEmpresaPracticas,
        string NitEmpresaPracticas,
        string RiesgoEstudiante,
        string NombrePersonaACargoPractica,
        string TelefonoPersonasACargo,
        string EmailPersonaACargoPractica,
        string FechaInicioPractica,
        string FechaTerminacionPractica,
        string Regional,
        string Seleccion,
        string JornadaEstablecida,
        string ModoPractica,
        string ZonaResidencial,
        string FechaSolicitud,
        string EstadoSolicitud,
        string Aprobo,
        string NombreAprobador,
        string MotivoAprobacion,
        string FechaRespuestaSolicitud,
        List<ArlFile> Archivos
        )
        : IRequest<ArlRequestDto>;
}
