using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
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
            this._accessKey = "AKIAV4V7LD4RPURCK5FM";
            this._secretKey = "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";
            this._config = new AmazonS3Config { RegionEndpoint = RegionEndpoint.USEast1 };
            this._bucketName = "gestion-documental-arl";
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
                    string base64String = file.ReferenciaArchivo;
                    string base64Prefix = "data:application/pdf;base64,";
                    string base64Data = string.Empty;

                    int prefixIndex = base64String.IndexOf(base64Prefix);
                    if (prefixIndex >= 0)
                    {
                        base64Data = base64String.Substring(prefixIndex + base64Prefix.Length);
                    }
                    if (prefixIndex < 0)
                    {
                        base64Data = base64String;
                    }
                    if (string.IsNullOrWhiteSpace(base64Data))
                    {
                        urls.Add("null");
                    }


                    // Decodificar el archivo Base64
                    byte[] pdfBytes = Convert.FromBase64String(base64Data);

                    // Subir el archivo a Amazon S3
                    string key = $"{NumeroIdentificacion}/{file.NombreArchivo}.pdf";
                    string url = await UploadFileToS3Async(client, pdfBytes, key, NumeroIdentificacion);

                    urls.Add(url);
                }
            }
            catch (Exception ex)
            {
                throw new("Ha ocurrido un error inesperado: " + ex.Message); // Re-lanza la excepción si es necesario.
            }

            return urls;
        }

        private async Task<string> UploadFileToS3Async(IAmazonS3 client, byte[] fileData, string key, string folder)
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

                return GetUrl(client as AmazonS3Client, _bucketName, key);
            }
        }

        private async Task<Dictionary<string, string>> GetFilesWithTokensAsync(IAmazonS3 s3Client, string bucketName, string folderName)
        {
            var prefix = folderName.EndsWith("/") ? folderName : folderName + "/";

            ListObjectsV2Request request = new ListObjectsV2Request
            {
                BucketName = bucketName,
                Prefix = prefix
            };

            ListObjectsV2Response response;
            try
            {
                response = await s3Client.ListObjectsV2Async(request);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error al listar objetos: " + e.Message);
                return null;
            }

            var filesWithTokens = new Dictionary<string, string>();

            foreach (var s3Object in response.S3Objects)
            {
                string objectKey = s3Object.Key;
                string tokenLink = GetUrl(s3Client as AmazonS3Client, bucketName, objectKey); // Genera el enlace con token

                filesWithTokens.Add(objectKey, tokenLink);
            }

            return filesWithTokens;
        }
        private string GetUrl(AmazonS3Client client, string bucketName, string objectKey, int durationInMinutes = 120)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                Expires = DateTime.Now.AddMinutes(durationInMinutes)
            };

            return client.GetPreSignedURL(request);
        }


    }
}
