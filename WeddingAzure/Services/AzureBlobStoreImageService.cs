using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;

namespace WeddingAzure.Services
{
    public class AzureBlobStoreImageService : IImageService
    {
        private readonly CloudBlobClient _cloudBlobClient;

        public AzureBlobStoreImageService(string accountName, string accountKey)
        {
            var blobStorageConnectionString = 
                $"DefaultEndpointsProtocol=https;AccountName={accountName};AccountKey={accountKey}";
            var account = CloudStorageAccount.Parse(blobStorageConnectionString);

            _cloudBlobClient = new CloudBlobClient(account.BlobEndpoint, account.Credentials);

            var requestOptions = new BlobRequestOptions
            {
                MaximumExecutionTime = TimeSpan.FromSeconds(30),
                RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(2), 1)
            };
            _cloudBlobClient.DefaultRequestOptions = requestOptions;
        }

        public string GetImageUri(string containerName, string path)
        {
            var container = _cloudBlobClient.GetContainerReference(containerName);
            var blob = container.GetBlobReference(path);
            return GetBlobSasUri(blob);
        }

        private static string GetBlobSasUri(CloudBlob blob)
        {
            var sasConstraints = new SharedAccessBlobPolicy
                {
                    SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5),
                    SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(24),
                    Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write
                };

            var sasBlobToken = blob.GetSharedAccessSignature(sasConstraints);
            return blob.Uri + sasBlobToken;
        }
    }

}