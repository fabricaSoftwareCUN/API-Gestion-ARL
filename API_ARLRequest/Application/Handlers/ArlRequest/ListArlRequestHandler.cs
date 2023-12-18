using API_ARLRequest.Application.DTOs;
using API_ARLRequest.Application.Queries.ArlRequest;
using API_ARLRequest.Infraestructure.AWS.AmazonS3.Services;
using API_ARLRequest.Infraestructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API_ARLRequest.Application.Handlers.ArlRequest
{
    public class ListArlRequestHandler : IRequestHandler<ListArlRequestsQuery, IEnumerable<ArlRequestDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly AmazonS3 _s3;
        public ListArlRequestHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _s3 = new AmazonS3();
        }

        public async Task<IEnumerable<ArlRequestDto>> Handle(ListArlRequestsQuery request, CancellationToken cancellationToken)
        {
            var arlRequests = await _dbContext.ArlRequests
                .Include(a => a.Archivos) 
                .ToListAsync(cancellationToken);

            var results = await Task.WhenAll(arlRequests.Select(async arlRequest =>
            {
                var links = await _s3.GetFilesWithTokensAsync(arlRequest.NumeroIdentificacion);
                links = links ?? new Dictionary<string, string>();
                var archivos = links.Select(sumadre => new ArlFileDto
                {
                    IdDocumentoARL = 1,
                    NombreArchivo = sumadre.Key.Split('/')[1].Replace(".pdf", ""),
                    ReferenciaArchivo = sumadre.Value != null ? sumadre.Value : "null"
                }).ToList();

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
                    //CorreoInstitucional = arlRequest.CorreoInstitucional,
                    NombreEmpresaPracticas = arlRequest.NombreEmpresaPracticas,
                    NitEmpresaPracticas = arlRequest.NitEmpresaPracticas,
                    //RiesgoEstudiante = arlRequest.RiesgoEstudiante,
                    NombrePersonaACargoPractica = arlRequest.NombrePersonaACargoPractica,
					TelefonoPersonasAcargoPractica = arlRequest.TelefonoPersonasAcargoPractica,
                    EmailPersonaACargoPractica = arlRequest.EmailPersonaACargoPractica,
                    FechaInicioPractica = arlRequest.FechaInicioPractica,
                    FechaTerminacionPractica = arlRequest.FechaTerminacionPractica,
                    //ActaInicioPractica = arlRequest.ActaInicioPractica,
                    Regional = arlRequest.Regional,
					Municipio = arlRequest.Municipio,
					//Seleccion = arlRequest.Seleccion,
					JornadaEstablecida = arlRequest.JornadaEstablecida,
                    ModoPractica = arlRequest.ModoPractica,
                    ZonaResidencial = arlRequest.ZonaResidencial,
                    FechaSolicitud = arlRequest.FechaSolicitud,
                    EstadoSolicitud = arlRequest.EstadoSolicitud,
                    //Aprobo = arlRequest.Aprobo,
                    NombreAprobador = arlRequest.NombreAprobador,
                    MotivoAprobacion = arlRequest.MotivoAprobacion,
                    FechaRespuestaSolicitud = arlRequest.FechaRespuestaSolicitud,
                    Archivos = archivos
                };
            }));
            return results;
        }
        internal class Pepito {
            public string nom_archivo { get; set; }
            public string link { get; set; }
        }
    }
}
