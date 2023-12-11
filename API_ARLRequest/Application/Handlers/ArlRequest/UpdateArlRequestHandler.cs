using API_ARLRequest.Application.Commands.ArlRequest;
using API_ARLRequest.Application.DTOs;
using API_ARLRequest.Infraestructure.Data;
using API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.DTOs;
using API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.Services;
using API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.Templates;
using MediatR;

namespace API_ARLRequest.Application.Handlers.ArlRequest
{
    public class UpdateArlRequestHandler : IRequestHandler<UpdateArlRequestCommand, ArlRequestDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ISendEmailService _sendEmailService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public UpdateArlRequestHandler(ApplicationDbContext context, ISendEmailService sendEmailService, IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = context;
            _sendEmailService = sendEmailService;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<ArlRequestDto> Handle(UpdateArlRequestCommand request, CancellationToken cancellationToken)
        {
            var arlRequest = await _dbContext.ArlRequests.FindAsync(
                new object[] { request.IdSolicitudArl }, cancellationToken);

            // VALIDACIONES con la solicitud que esta en base de datos
            if (arlRequest == null)
            {
                throw new InvalidOperationException("No es una solicitud valida para resolver.");
            }
            /*if (arlRequest.EstadoSolicitud == "APROBADA" || arlRequest.EstadoSolicitud == "RECHAZADA")
            {
                throw new InvalidOperationException("La solicitud ya ha sido resuelta, no es posible modificar su estado.");
            }*/           

            DateTime dateTime = DateTime.Now;
            var fechaFormateada = dateTime.ToString();

            // Actualizar el registro existente con los campos recibidos
            arlRequest.EstadoSolicitud = request.EstadoSolicitud;
            arlRequest.NombreAprobador = request.NombreAprobador;
            arlRequest.MotivoAprobacion = request.MotivoAprobacion;
            arlRequest.FechaRespuestaSolicitud = fechaFormateada;


            await _dbContext.SaveChangesAsync(cancellationToken);


            // Logica para enviar Email
            /*try
            {
                var name = arlRequest.NombreEstudiante;
                var reason = arlRequest.MotivoAprobacion;

                string rutaBasePro = AppContext.BaseDirectory;
                string rutaBase = _hostingEnvironment.ContentRootPath;
                string templatePath = Path.Combine(rutaBasePro, "API_ARLRequest", "Infraestructure", "Services", "EmailServiceSMTP", "Templates");
                string template = "";

                switch (reason)
                {
                    case "ARL APROBADA":
                        templatePath = "ArlAprobada.html";
                        break;
                    case "ACTA DE INICIO MAL DILIGENCIADA":
                        template = "ActaInicioMalDiligenciada.html";
                        break;
                    case "PROBLEMAS DOCUMENTOS SOPORTES":
                        templatePath = "ProblemasDocumentos.html";
                        break;
                    case "EMPRESA ASUME ARL":
                        templatePath = "EmpresaAsumeARL.html";
                        break;
                    case "DURACIÓN DE LAS PRÁCTICAS":
                        templatePath = "DuracionPracticas.html";
                        break;
                    case "NO APROBADO POR CUN":
                        templatePath = "NoAprobadoCUN.html";
                        break;
                    default:
                        templatePath = "NoAprobadoCUN.html";
                        break;
                }

                string rutaCompleta = Path.Combine(templatePath, template);

                var templateContent = File.ReadAllText(rutaCompleta);
                templateContent = templateContent.Replace("{{Nombre}}", name);


                var sendEmail = new SendEmailDTO()
                {
                    To = arlRequest.EmailEstudiante,
                    Subject = reason,
                    Body = templateContent
                };
                _sendEmailService.SendEmail(sendEmail);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("El correo no se envio." + ex); ;
            }
            */


            try
            {
                var nombre = arlRequest.NombreEstudiante; // Aquí obtienes dinámicamente el nombre

                var emailTemplateService = new EmailTemplates();

                string template = arlRequest.MotivoAprobacion;

                string templateAprobada = emailTemplateService.GetTemplate(template);


                //var templateContent = File.ReadAllText(templateAprobada);
                templateAprobada = templateAprobada.Replace("{{Nombre}}", nombre);

                var sendEmail = new SendEmailDTO()
                {
                    To = arlRequest.EmailEstudiante,
                    Subject = "Resolución Solicitud ARL",
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
