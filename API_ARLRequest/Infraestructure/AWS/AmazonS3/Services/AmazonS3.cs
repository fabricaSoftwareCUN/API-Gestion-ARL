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

            using var client = new AmazonS3Client(this.credentials, this._config);

            
            if (arlFiles != null && arlFiles.Count > 0)
            {
                foreach (var file in arlFiles)
                {
                    byte[] pdfBytes = Convert.FromBase64String(file.ReferenciaArchivo);

                    using (MemoryStream pdfStream = new MemoryStream(pdfBytes))
                    {
                        var fileTransferUtility = new TransferUtility(client);

                        var key = NumeroIdentificacion + "/" + file.NombreArchivo + ".pdf";

                        var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                        {
                            BucketName = _bucketName,
                            InputStream = pdfStream,
                            Key = key
                        };

                        await fileTransferUtility.UploadAsync(fileTransferUtilityRequest);

                        string url = $"https://{_bucketName}.s3.amazonaws.com/{key}";
                        urls.Add(url);
                    }
                }
            }
            return urls;
        }



    }
}
