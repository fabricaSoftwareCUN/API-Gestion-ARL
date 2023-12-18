namespace API_ARLRequest.Infraestructure.Services.EmailServiceSMTP.Templates
{
    public class EmailTemplates
    {

        public string GetTemplate(string templateName)
        {
            switch (templateName)
            {
                case "SOLICITUD PENDIENTE":
                    return @"<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <style>
        /* Estilos globales */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            color: #000;
            box-sizing: content-box;
        }

        /* Estilos específicos para el contenedor principal */
        .container {
            width: 100%;
            max-width: 700px;
            margin: 0 auto;
            padding: 0px;
            background-color: #fff;
            border-radius: 8px;
            overflow: hidden; 
        }

        /* Contenido del Email */
        .content{
            font-size: 15px;
            padding: 0 30px;
            border-right: 4px dotted #90EE90;            
            border-left: 4px dotted #90EE90;
            display: inline-block;
                       
        }


        /* Estilos para los encabezados */
        h1 {
            font-size: 26px;
            margin: 15px 0;
        }
        h3 {
            font-size: 16px;
            margin: 0px 0px 12px;
            display: inline-block;
        }

        /* Estilos para los enlaces */
        a {
            color: #007bff;
        }

        /* Estilos para las secciones */
        .section {
            margin-bottom: 30px;

        }

        /* Estilos del banner */
        .banner-container {
            max-width: 100%;
            height: auto;
            margin: 0px auto;
            line-height: 0;
        }

        .banner-img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }
    </style>
</head>
<body>
    <div class=""container"">

    <!-- HEADER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/header-mailing.png"" alt=""Banner"" />
        </div>

    <!-- CONTENT -->
        <div class=""content"">
            <h1>Solicitud de ARL Pendiente</h1>
            
            <div class=""section"">
                <p>Estimado(a) {{Nombre}},</p>
                <p>Esperamos que te encuentres bien. Queremos confirmarte que hemos recibido tu solicitud de ARL. Nuestro equipo se encuentra revisando tu solicitud y recibirás una notificación tan pronto como tengamos una actualización.</p>
                <p>Gracias por tu paciencia y comprensión. Estamos trabajando para procesar tu solicitud lo antes posible.</p>
                <p>Atentamente,</p>
                <p>El equipo responsable de ARL</p>


                <br>                
                <p>Si tienes alguna duda no dudes en contactar a tu docente <a href=""https://app.powerbi.com/view?r=eyJrIjoiZDhjZjNmMzYtM2I4Yi00YjBhLTkzNGMtN2NkNDM0ZjMyY2YyIiwidCI6IjUyMDlhOGNhLTc1ZGQtNGVhMy05MDc0LTZjMDAwMzMzMzQ4YiIsImMiOjR9"">aquí</a>.</p>

            </div>
        </div>

    <!-- FOOTER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/footer-mailing.png"" alt=""Banner"" />
        </div>
    </div>
</body>
</html>
";
                case "ARL APROBADA":
                    return @"<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <style>
        /* Estilos globales */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            color: #000;
            box-sizing: content-box;
        }

        /* Estilos específicos para el contenedor principal */
        .container {
            width: 100%;
            max-width: 700px;
            margin: 0 auto;
            padding: 0px;
            background-color: #fff;
            border-radius: 8px;
            overflow: hidden; 
        }

        /* Contenido del Email */
        .content{
            font-size: 15px;
            padding: 0 30px;
            border-right: 4px dotted #90EE90;            
            border-left: 4px dotted #90EE90;
            display: inline-block;
                       
        }


        /* Estilos para los encabezados */
        h1 {
            font-size: 26px;
            margin: 15px 0;
        }
        h3 {
            font-size: 16px;
            margin: 0px 0px 12px;
            display: inline-block;
        }

        /* Estilos para los enlaces */
        a {
            color: #007bff;
        }

        /* Estilos para las secciones */
        .section {
            margin-bottom: 30px;

        }

        /* Estilos del banner */
        .banner-container {
            max-width: 100%;
            height: auto;
            margin: 0px auto;
            line-height: 0;
        }

        .banner-img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }
    </style>
</head>
<body>
    <div class=""container"">

    <!-- HEADER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/header-mailing.png"" alt=""Banner"" />
        </div>

    <!-- CONTENT -->
        <div class=""content"">
            <h1>ARL APROBADA</h1>
            
            <div class=""section"">
                <p>Estimado(a) {{Nombre}}, espero que estés muy bien. Te informamos que tu solicitud de ARL ha sido APROBADA. El certificado será enviado a tu correo institucional @cun.edu.co a más tardar el día de inicio de tu práctica.</p>
                <p>Si tienes alguna duda no dudes en contactar a tu docente <a href=""https://app.powerbi.com/view?r=eyJrIjoiZDhjZjNmMzYtM2I4Yi00YjBhLTkzNGMtN2NkNDM0ZjMyY2YyIiwidCI6IjUyMDlhOGNhLTc1ZGQtNGVhMy05MDc0LTZjMDAwMzMzMzQ4YiIsImMiOjR9 "">aquí</a>.</p>
            </div>

        </div>

    <!-- FOOTER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/footer-mailing.png"" alt=""Banner"" />
        </div>
    </div>
</body>
</html>";
                case "ACTA DE INICIO MAL DILIGENCIADA":
                    return @"<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <style>
        /* Estilos globales */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            color: #000;
            box-sizing: content-box;
        }

        /* Estilos específicos para el contenedor principal */
        .container {
            width: 100%;
            max-width: 700px;
            margin: 0 auto;
            padding: 0px;
            background-color: #fff;
            border-radius: 8px;
            overflow: hidden; 
        }

        /* Contenido del Email */
        .content{
            font-size: 15px;
            padding: 0 30px;
            border-right: 4px dotted #90EE90;            
            border-left: 4px dotted #90EE90;
            display: inline-block;
                       
        }


        /* Estilos para los encabezados */
        h1 {
            font-size: 26px;
            margin: 15px 0;
        }
        h3 {
            font-size: 16px;
            margin: 0px 0px 12px;
            display: inline-block;
        }

        /* Estilos para los enlaces */
        a {
            color: #007bff;
        }

        /* Estilos para las secciones */
        .section {
            margin-bottom: 30px;

        }

        /* Estilos del banner */
        .banner-container {
            max-width: 100%;
            height: auto;
            margin: 0px auto;
            line-height: 0;
        }

        .banner-img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }
    </style>
</head>
<body>
    <div class=""container"">

    <!-- HEADER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/header-mailing.png"" alt=""Banner"" />
        </div>

     <!-- CONTENT -->
     <div class=""content"">
        <h1>ARL RECHAZADA</h1>
        <h3>ACTA DE INICIO MAL DILIGENCIADA</h3>

        
        <div class=""section"">
            <p>Estimado(a) {{Nombre}}, espero que estés muy bien. Tu solicitud de afiliación a ARL ha sido RECHAZADA. Es importante recordar que este documento es de gran importancia y debe contener obligatoriamente la siguiente información:</p>
            <ul>
                <li>Datos del sitio de prácticas</li>
                <li>Datos del monitor designado por la empresa para el seguimiento</li>
                <li>Datos del tutor, docente designado por la CUN</li>
                <li>Fecha de inicio y de finalización</li>
                <li>Funciones pertinentes al programa y nivel de formación</li>
                <li>Obligaciones del estudiante</li>
                <li>Obligaciones de la empresa</li>
                <li>Firma de la persona responsable de la vinculación o monitor y del practicante</li>
            </ul>
            <p>Por favor, asegúrate de que contenga esta información. En el siguiente enlace podrá encontrar un modelo instructivo de cómo diligenciar el acta de manera correcta para que tu solicitud de afiliación sea exitosa.</p>
            <p>Si tienes alguna duda no dudes en contactar a tu docente <a href=""https://app.powerbi.com/view?r=eyJrIjoiZDhjZjNmMzYtM2I4Yi00YjBhLTkzNGMtN2NkNDM0ZjMyY2YyIiwidCI6IjUyMDlhOGNhLTc1ZGQtNGVhMy05MDc0LTZjMDAwMzMzMzQ4YiIsImMiOjR9 "">aquí</a>.</p>
        </div>
    </div>

    <!-- FOOTER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/footer-mailing.png"" alt=""Banner"" />
        </div>
    </div>
</body>
</html>";
                case "PROBLEMAS DOCUMENTOS SOPORTES":
                    return @"<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <style>
        /* Estilos globales */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            color: #000;
            box-sizing: content-box;
        }

        /* Estilos específicos para el contenedor principal */
        .container {
            width: 100%;
            max-width: 700px;
            margin: 0 auto;
            padding: 0px;
            background-color: #fff;
            border-radius: 8px;
            overflow: hidden; 
        }

        /* Contenido del Email */
        .content{
            font-size: 15px;
            padding: 0 30px;
            border-right: 4px dotted #90EE90;            
            border-left: 4px dotted #90EE90;
            display: inline-block;
                       
        }


        /* Estilos para los encabezados */
        h1 {
            font-size: 26px;
            margin: 15px 0;
        }
        h3 {
            font-size: 16px;
            margin: 0px 0px 12px;
            display: inline-block;
        }

        /* Estilos para los enlaces */
        a {
            color: #007bff;
        }

        /* Estilos para las secciones */
        .section {
            margin-bottom: 30px;

        }

        /* Estilos del banner */
        .banner-container {
            max-width: 100%;
            height: auto;
            margin: 0px auto;
            line-height: 0;
        }

        .banner-img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }
    </style>
</head>
<body>
    <div class=""container"">

    <!-- HEADER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/header-mailing.png"" alt=""Banner"" />
        </div>

        <!-- CONTENT -->
        <div class=""content"">
            <h1>ARL RECHAZADA</h1>
            <h3>PROBLEMAS DOCUMENTOS SOPORTES</h3>
            
            <div class=""section"">
                <p>Estimado(a) {{Nombre}}, espero que estés muy bien. Lamentamos informarte que tu solicitud de afiliación a ARL ha sido RECHAZADA, debido a que algunos de los documentos cargados no cumplen con los siguientes criterios:</p>
                <ul>
                    <li>Legibilidad: Algunos de los documentos no son legibles. Recuerda que el documento de identidad debe estar ampliado al 150%.</li>
                    <li>Fecha de expedición: Algunos documentos no son recientes, ya que la fecha de expedición no debe ser mayor a 30 días.</li>
                    <li>Correspondencia: Algunos documentos no concuerdan con lo solicitado. El certificado de afiliación al sistema de seguridad social debe indicar que estás activo.</li>
                </ul>
                <P>Lamentamos los inconvenientes ocasionados y te invitamos a realizar las correcciones necesarias para que tu solicitud pueda ser procesada satisfactoriamente en el futuro.</P>
                <p>Por favor, asegúrate de adjuntar documentos actualizados para que puedas volver a realizar el proceso de afiliación de manera exitosa a través de este <a href=""https://repo.cunapp.dev/web/2023/publicaciones/practicas-paso-paso.pdf"">enlace</a>.</p>
                <p>Si tienes alguna pregunta o duda, no dudes en contactar a tu docente <a href=""https://app.powerbi.com/view?r=eyJrIjoiZDhjZjNmMzYtM2I4Yi00YjBhLTkzNGMtN2NkNDM0ZjMyY2YyIiwidCI6IjUyMDlhOGNhLTc1ZGQtNGVhMy05MDc0LTZjMDAwMzMzMzQ4YiIsImMiOjR9 "">aquí</a>.</p>
            </div>
        </div>

    <!-- FOOTER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/footer-mailing.png"" alt=""Banner"" />
        </div>
    </div>
</body>
</html>";
                case "EMPRESA ASUME ARL":
                    return @"<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <style>
        /* Estilos globales */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            color: #000;
            box-sizing: content-box;
        }

        /* Estilos específicos para el contenedor principal */
        .container {
            width: 100%;
            max-width: 700px;
            margin: 0 auto;
            padding: 0px;
            background-color: #fff;
            border-radius: 8px;
            overflow: hidden; 
        }

        /* Contenido del Email */
        .content{
            font-size: 15px;
            padding: 0 30px;
            border-right: 4px dotted #90EE90;            
            border-left: 4px dotted #90EE90;
            display: inline-block;
                       
        }


        /* Estilos para los encabezados */
        h1 {
            font-size: 26px;
            margin: 15px 0;
        }
        h3 {
            font-size: 16px;
            margin: 0px 0px 12px;
            display: inline-block;
        }

        /* Estilos para los enlaces */
        a {
            color: #007bff;
        }

        /* Estilos para las secciones */
        .section {
            margin-bottom: 30px;

        }

        /* Estilos del banner */
        .banner-container {
            max-width: 100%;
            height: auto;
            margin: 0px auto;
            line-height: 0;
        }

        .banner-img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }
    </style>
</head>
<body>
    <div class=""container"">

    <!-- HEADER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/header-mailing.png"" alt=""Banner"" />
        </div>

        <!-- CONTENT -->
        <div class=""content"">
            <h1>ARL RECHAZADA</h1>
            <h3>EMPRESA ASUME ARL</h3>
            
            <div class=""section"">
                <p>Estimado(a) {{Nombre}}, espero que estés muy bien. Lamentamos informarte que tu solicitud de ARL ha sido RECHAZADA. Esto se debe a que, de acuerdo con el Numeral 2 del Artículo 4 del Decreto 055 del 2015, las empresas de régimen privado son las responsables de asumir la afiliación a la ARL y el pago de los aportes al sistema general de riesgos profesionales de los estudiantes que realicen sus prácticas en sus instalaciones.</p>
                <p>Lamentamos cualquier inconveniente que esto pueda causarte y te recomendamos ponerte en contacto con tu empresa para garantizar que se cumplan los requisitos necesarios para tu afiliación a la ARL.</p>
                <p>Recuerda que el acta de inicio o acuerdo tripartito debe contener obligatoriamente la siguiente información:</p>
                <ul>
                    <li>Datos del sitio de prácticas</li>
                    <li>Datos del monitor designado por la empresa para el seguimiento</li>
                    <li>Datos del tutor, docente designado por la CUN</li>
                    <li>Fecha de inicio y de finalización</li>
                    <li>Funciones pertinentes al programa y nivel de formación</li>
                    <li>Obligaciones del estudiante</li>
                    <li>Obligaciones de la empresa</li>
                    <li>Firma de la persona responsable de la vinculación o monitor y del practicante</li>
                </ul>
                <p>Por favor, asegúrate de adjuntar documentos actualizados para que puedas volver a realizar el proceso de afiliación de manera exitosa a través de este <a href=""https://repo.cunapp.dev/web/2023/publicaciones/practicas-paso-paso.pdf"">enlace</a>.</p>
                <p>Si tienes alguna pregunta o duda, no dudes en contactar a tu docente <a href=""https://app.powerbi.com/view?r=eyJrIjoiZDhjZjNmMzYtM2I4Yi00YjBhLTkzNGMtN2NkNDM0ZjMyY2YyIiwidCI6IjUyMDlhOGNhLTc1ZGQtNGVhMy05MDc0LTZjMDAwMzMzMzQ4YiIsImMiOjR9 "">aquí</a>.</p>
            </div>
        </div>

    <!-- FOOTER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/footer-mailing.png"" alt=""Banner"" />
        </div>
    </div>
</body>
</html>";
                case "DURACIÓN DE LAS PRÁCTICAS":
                    return @"<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <style>
        /* Estilos globales */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            color: #000;
            box-sizing: content-box;
        }

        /* Estilos específicos para el contenedor principal */
        .container {
            width: 100%;
            max-width: 700px;
            margin: 0 auto;
            padding: 0px;
            background-color: #fff;
            border-radius: 8px;
            overflow: hidden; 
        }

        /* Contenido del Email */
        .content{
            font-size: 15px;
            padding: 0 30px;
            border-right: 4px dotted #90EE90;            
            border-left: 4px dotted #90EE90;
            display: inline-block;
                       
        }


        /* Estilos para los encabezados */
        h1 {
            font-size: 26px;
            margin: 15px 0;
        }
        h3 {
            font-size: 16px;
            margin: 0px 0px 12px;
            display: inline-block;
        }

        /* Estilos para los enlaces */
        a {
            color: #007bff;
        }

        /* Estilos para las secciones */
        .section {
            margin-bottom: 30px;

        }

        /* Estilos del banner */
        .banner-container {
            max-width: 100%;
            height: auto;
            margin: 0px auto;
            line-height: 0;
        }

        .banner-img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }
    </style>
</head>
<body>
    <div class=""container"">

    <!-- HEADER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/header-mailing.png"" alt=""Banner"" />
        </div>

        <!-- CONTENT -->
        <div class=""content"">
            <h1>ARL RECHAZADA</h1>
            <h3>DURACIÓN DE LAS PRÁCTICAS</h3>
            
            <div class=""section"">
                <p>Estimado(a) {{Nombre}}, espero que estés muy bien. Lamentamos informarte que tu solicitud de afiliación a ARL ha sido RECHAZADA. Es importante tener en cuenta que el periodo mínimo para gestionar la afiliación es de un mes calendario.</p>
                <p>Si tienes alguna pregunta o duda, no dudes en contactar a tu docente <a href=""https://app.powerbi.com/view?r=eyJrIjoiZDhjZjNmMzYtM2I4Yi00YjBhLTkzNGMtN2NkNDM0ZjMyY2YyIiwidCI6IjUyMDlhOGNhLTc1ZGQtNGVhMy05MDc0LTZjMDAwMzMzMzQ4YiIsImMiOjR9 "">aquí</a>.</p>
            </div>
        </div>

    <!-- FOOTER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/footer-mailing.png"" alt=""Banner"" />
        </div>
    </div>
</body>
</html>";
                case "NO APROBADO POR CUN":
                    return @"<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <style>
        /* Estilos globales */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            color: #000;
            box-sizing: content-box;
        }

        /* Estilos específicos para el contenedor principal */
        .container {
            width: 100%;
            max-width: 700px;
            margin: 0 auto;
            padding: 0px;
            background-color: #fff;
            border-radius: 8px;
            overflow: hidden; 
        }

        /* Contenido del Email */
        .content{
            font-size: 15px;
            padding: 0 30px;
            border-right: 4px dotted #90EE90;            
            border-left: 4px dotted #90EE90;
            display: inline-block;
                       
        }


        /* Estilos para los encabezados */
        h1 {
            font-size: 26px;
            margin: 15px 0;
        }
        h3 {
            font-size: 16px;
            margin: 0px 0px 12px;
            display: inline-block;
        }

        /* Estilos para los enlaces */
        a {
            color: #007bff;
        }

        /* Estilos para las secciones */
        .section {
            margin-bottom: 30px;

        }

        /* Estilos del banner */
        .banner-container {
            max-width: 100%;
            height: auto;
            margin: 0px auto;
            line-height: 0;
        }

        .banner-img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }
    </style>
</head>
<body>
    <div class=""container"">

    <!-- HEADER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/header-mailing.png"" alt=""Banner"" />
        </div>

        <!-- CONTENT -->
        <div class=""content"">
            <h1>ARL RECHAZADA</h1>
            <h3>NO APROBADO POR CUN</h3>
            
            <div class=""section"">
                <p>Estimado(a) {{Nombre}}, espero que estés muy bien. Lamentamos informarte que tu solicitud de afiliación a ARL ha sido RECHAZADA. Es importante tener en cuenta que, para realizar la práctica en las áreas articuladas a CUN <b>(Cunbre, Monitoria, Práctica Social, Práctica de Investigación y Pasantía)</b>, debes contar con el aval correspondiente del área. Hemos validado que no estás aprobado por el área correspondiente. Te recomendamos contactarlos para obtener el aval necesario y asegurarte de cumplir con los requisitos antes de presentar nuevamente tu solicitud.</p>
                <p>Si tienes alguna pregunta o duda, no dudes en contactar a tu docente <a href=""https://app.powerbi.com/view?r=eyJrIjoiZDhjZjNmMzYtM2I4Yi00YjBhLTkzNGMtN2NkNDM0ZjMyY2YyIiwidCI6IjUyMDlhOGNhLTc1ZGQtNGVhMy05MDc0LTZjMDAwMzMzMzQ4YiIsImMiOjR9 "">aquí</a>.</p>
            </div>
        </div>

    <!-- FOOTER -->
        <div class=""banner-container"">
            <img class=""banner-img"" src=""https://repocun.s3.us-east-2.amazonaws.com/fabrica_software/correo_arl/footer-mailing.png"" alt=""Banner"" />
        </div>
    </div>
</body>
</html>";
                // Agrega más casos para otros templates
                default:
                    return string.Empty;
            }
        }

    }
}
