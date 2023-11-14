using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using API_ARLRequest.Application.DTOs;
using API_ARLRequest.Domain;
using API_ARLRequest.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API_ARLRequest.Infraestructure.AWS.AmazonS3.Services

{
    public class AmazonS3
    {
        private string _accessKey;
        private string _secretKey;
        private AmazonS3Config _config;
        private string _bucketName;
        private AWSCredentials credentials;
        private readonly ApplicationDbContext _dbContext;

        public AmazonS3(ApplicationDbContext dbContext)
        {
            this._accessKey = "AKIAW7YBK325DVJBMBHI";
            this._secretKey = "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";
            this._config = new AmazonS3Config { RegionEndpoint = RegionEndpoint.USEast1 };
            this._bucketName = "cun-test-arl-request";
            this.credentials = new BasicAWSCredentials(this._accessKey, this._secretKey);
            this._dbContext = dbContext;
        }

        public async Task<List<String>> UploadFilesToS3Async(List<ArlFile> arlFiles, string NumeroIdentificacion)
        {
            List<string> urls = new List<string>();


            if (arlFiles == null || arlFiles.Count == 0)
            {
                return urls; // No hay archivos para subir.
            }

            try
            {
                using var client = new AmazonS3Client(this.credentials, this._config);

                foreach (var file in arlFiles)
                {
                    // Validación de Base64
                    /*if (!IsBase64String(file.ReferenciaArchivo))
                    {
                        // Manejo de archivos no válidos
                        //Log.Warning($"Archivo no válido: {file.NombreArchivo}");
                        urls.Add("null");
                        continue; // Salta este archivo y continúa con el siguiente.
                    }*/
                    if(string.IsNullOrWhiteSpace(file.ReferenciaArchivo))
                    {
                        urls.Add("null");
                    }



                    // Decodificar el archivo Base64
                    byte[] pdfBytes = Convert.FromBase64String(file.ReferenciaArchivo);

                    // Subir el archivo a Amazon S3
                    string key = $"{NumeroIdentificacion}/{file.NombreArchivo}.pdf";
                    string url = await UploadFileToS3Async(client, pdfBytes, key);

                    urls.Add(url);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: Registra o maneja la excepción según tus necesidades.
                // También puedes agregar métricas o notificaciones aquí para monitorizar problemas.
                //Log.Error(ex, "Error al subir archivos a Amazon S3");
                throw new("Ha ocurrido un error inesperado: " + ex.Message); // Re-lanza la excepción si es necesario.
            }

            return urls;
        }

        private async Task<string> UploadFileToS3Async(IAmazonS3 client, byte[] fileData, string key)
        {
            using (MemoryStream memoryStream = new MemoryStream(fileData))
            {
                var fileTransferUtility = new TransferUtility(client);

                var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = _bucketName,
                    InputStream = memoryStream,
                    Key = key
                };

                await fileTransferUtility.UploadAsync(fileTransferUtilityRequest);

                return $"https://{_bucketName}.s3.amazonaws.com/{key}";
            }
        }

        private bool IsBase64String(string s)
        {
            // Validación simple para verificar si una cadena es Base64 válida
            if (string.IsNullOrWhiteSpace(s) || s.Length % 4 != 0)
            {
                return false;
            }
            try
            {
                Convert.FromBase64String(s);
                return true;
            }
            catch
            {
                return false;
            }



        }



    }
}
