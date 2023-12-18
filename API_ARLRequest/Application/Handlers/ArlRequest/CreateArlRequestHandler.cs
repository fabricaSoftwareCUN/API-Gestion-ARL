using API_ARLRequest.Application.Commands.ArlRequest;
using API_ARLRequest.Application.DTOs;
using API_ARLRequest.Domain;
using API_ARLRequest.Infraestructure.AWS.AmazonS3.Services;
using API_ARLRequest.Infraestructure.Data;
using API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.DTOs;
using API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.Services;
using API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.Templates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API_ARLRequest.Application.Handlers.ArlRequest
{
    public class CreateArlRequestHandler : IRequestHandler<CreateArlRequestCommand, ArlRequestDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly AmazonS3 _amazonS3;
        private readonly ISendEmailService _sendEmailService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CreateArlRequestHandler(ApplicationDbContext dbContext, AmazonS3 amazonS3, ISendEmailService sendEmailService, IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _amazonS3 = amazonS3;
            _sendEmailService = sendEmailService;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<ArlRequestDto> Handle(CreateArlRequestCommand request, CancellationToken cancellationToken)
        {
            var existingPendingRequest = await _dbContext.ArlRequests
                .FirstOrDefaultAsync(a => 
                (a.NumeroIdentificacion == request.NumeroIdentificacion.ToString() ||
                a.EmailEstudiante == request.EmailEstudiante) && 
                a.EstadoSolicitud == "Pendiente"
                );

            if (existingPendingRequest != null)
            {
                // Ya existe una solicitud pendiente, lanzar una excepción o devolver un mensaje de error.
                throw new InvalidOperationException("Ya existe una solicitud pendiente con el mismo número de identificación o correo electrónico.");
            }

            var urls = new List<string>();

            if (request.Archivos != null && request.Archivos.Count > 0)
            {
                urls = await _amazonS3.UploadFilesToS3Async(request.Archivos, request.NumeroIdentificacion.ToString());
            }


            DateTime dateTime = DateTime.Now;
            var fechaFormateada = dateTime.ToString();

            var arlRequest = new Domain.ArlRequest()
            {
                NumeroIdentificacion = request.NumeroIdentificacion.ToString(),
                TipoIdentificacion = request.TipoIdentificacion,
                NombreEstudiante = request.NombreEstudiante,
                EmailEstudiante = request.EmailEstudiante,
                ModalidadPractica = request.ModalidadPractica,
                PeriodoAcademico = request.PeriodoAcademico,
                CapaOcho = request.CapaOcho.ToString(),
                ProgramaAcademico = request.ProgramaAcademico,
                TipoPractica = request.TipoPractica,
                NombreEmprendimiento = request.NombreEmprendimiento,
                NitEmprendimiento = request.NitEmprendimiento != 0 ? request.NitEmprendimiento.ToString() : "N/A",
                FechaNacimiento = request.FechaNacimiento,
                EpsEstudiante = request.EpsEstudiante,
                NumeroTelEstudiante = request.NumeroTelEstudiante.ToString(),
                //CorreoInstitucional = request.CorreoInstitucional,
                NombreEmpresaPracticas = request.NombreEmpresaPracticas,
                NitEmpresaPracticas = request.NitEmpresaPracticas,
                //NitEmpresaPracticas = request.NitEmpresaPracticas != 0 ? request.NitEmpresaPracticas.ToString() : "N/A",
                //RiesgoEstudiante = request.RiesgoEstudiante,
                NombrePersonaACargoPractica = request.NombrePersonaACargoPractica,
				TelefonoPersonasAcargoPractica = request.TelefonoPersonasAcargoPractica,
                EmailPersonaACargoPractica = request.EmailPersonaACargoPractica,
                FechaInicioPractica = request.FechaInicioPractica,
                FechaTerminacionPractica = request.FechaTerminacionPractica,
                Regional = request.Regional,
				Municipio = request.Municipio,
				//Seleccion = request.Seleccion,
				JornadaEstablecida = request.JornadaEstablecida,
                ModoPractica = request.ModoPractica,
                ZonaResidencial = request.ZonaResidencial,
                FechaSolicitud = fechaFormateada,
                EstadoSolicitud = "PENDIENTE",
                NombreAprobador = request.NombreAprobador,
                MotivoAprobacion = request.MotivoAprobacion,
                FechaRespuestaSolicitud = request.FechaRespuestaSolicitud,
                Archivos = request.Archivos.Select((f, i) => new ArlFile
                {
                    NombreArchivo = f.NombreArchivo,
                    ReferenciaArchivo = urls[i]
                }).ToList()
            };

            _dbContext.ArlRequests.Add(arlRequest);
            await _dbContext.SaveChangesAsync(cancellationToken);

            /*try
            {

                string rutaBase = _hostingEnvironment.ContentRootPath;
                string templatePath = Path.Combine(rutaBase, "Infraestructure", "Services", "EmailServiceSMTP", "Templates");
                string template = "SolicitudPendiente.html";


                string rutaCompleta = Path.Combine(templatePath, template);

                var templateContent = File.ReadAllText(rutaCompleta);

                var nombre = arlRequest.NombreEstudiante; // Aquí obtienes dinámicamente el nombre

                // Reemplaza el marcador de posición {{Nombre}} con el nombre específico
                templateContent = templateContent.Replace("{{Nombre}}", nombre);


                var sendEmail = new SendEmailDTO()
                {
                    To = request.EmailEstudiante,
                    Subject = "Solicitud ARL",
                    Body = templateContent
                };
                _sendEmailService.SendEmail(sendEmail);
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("Ha ocurrido un error al enviar el email." + ex.Message); ;
            }*/

            try
            {
                var nombre = arlRequest.NombreEstudiante; // Aquí obtienes dinámicamente el nombre

                var emailTemplateService = new EmailTemplates();
                string templateAprobada = emailTemplateService.GetTemplate("SOLICITUD PENDIENTE");


                //var templateContent = File.ReadAllText(templateAprobada);
                templateAprobada = templateAprobada.Replace("{{Nombre}}", nombre);

                var sendEmail = new SendEmailDTO()
                {
                    To = request.EmailEstudiante,
                    Subject = "Solicitud ARL",
                    Body = templateAprobada
                };
                _sendEmailService.SendEmail(sendEmail);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ha ocurrido un error al enviar el email." + ex.Message); ;
            }


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
                //Aprobo = arlRequest.Aprobo,
                ZonaResidencial = arlRequest.ZonaResidencial,
                FechaSolicitud = arlRequest.FechaSolicitud,
                EstadoSolicitud = arlRequest.EstadoSolicitud,
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
