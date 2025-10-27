using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;

namespace Hyper_Radio_API.Services.UploadServices;

public class AzureBlobService
{
    private readonly BlobContainerClient _containerClient;

    public AzureBlobService(IOptions<AzureBlobSettings> options)
    {
        var settings = options.Value;

        if (string.IsNullOrEmpty(settings.ConnectionString))
            throw new ArgumentNullException(nameof(settings.ConnectionString));

        var blobServiceClient = new BlobServiceClient(settings.ConnectionString);
        _containerClient = blobServiceClient.GetBlobContainerClient(settings.ContainerName);
        _containerClient.CreateIfNotExists();
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
    {
        var blobClient = _containerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(fileStream, overwrite: true);
        return blobClient.Uri.ToString();
    }

    public async Task<string> DownloadFileAsync(string blobName, string localPath)
    {
        var blobClient = _containerClient.GetBlobClient(blobName);
        await blobClient.DownloadToAsync(localPath);
        return localPath;
    }

    public async Task<List<string>> UploadDirectoryAsync(string directory, string trackFolder)
    {
        var urls = new List<string>();
        foreach (var file in Directory.GetFiles(directory))
        {
            await using var stream = File.OpenRead(file);
            var fileName = Path.GetFileName(file);
            var blobClient = _containerClient.GetBlobClient($"{trackFolder}/{fileName}");
            await blobClient.UploadAsync(stream, overwrite: true);
            urls.Add(blobClient.Uri.ToString());
        }
        return urls;
    }
}

public class AzureBlobSettings
{
    public string ConnectionString { get; set; } = default!;
    public string ContainerName { get; set; } = default!;
}
