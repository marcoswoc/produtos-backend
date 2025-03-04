using Azure.Storage.Blobs;

namespace Produtos.Infrastructure.Storage;
public class AzureStorageService(string _connectionString)
{   
    public async Task<string> UploadBlobAsync(string containerName, string blobName, Stream fileStream)
    {   
        var blobServiceClient = new BlobServiceClient(_connectionString);
     
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
        await blobContainerClient.CreateIfNotExistsAsync();
        
        var blobClient = blobContainerClient.GetBlobClient(blobName);
        
        await blobClient.UploadAsync(fileStream, overwrite: true);

        return blobClient.Uri.ToString();
    }
}

