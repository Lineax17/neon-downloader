namespace Core;

using System.Net.Http;
using System.IO;

/// <summary>
/// Provides functionality to download files from URLs to the local file system.
/// </summary>
public class Download
{
    private static readonly HttpClient _httpClient = new HttpClient();
    private String _filePath;

    /// <summary>
    /// Event that reports download progress as percentage (0-100).
    /// </summary>
    public event EventHandler<double>? ProgressChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="Download"/> class with the default download directory.
    /// </summary>
    public Download()
    {
        this._filePath = PathHelper.getDownloadDirectory();
        
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Download"/> class with a custom file path.
    /// </summary>
    /// <param name="filePath">The directory path where files will be downloaded.</param>
    public Download(String filePath)
    {
        this._filePath = filePath;
    }
    
    /// <summary>
    /// Downloads a file from the specified URL asynchronously. The filename is extracted from the URL.
    /// Subscribe to ProgressChanged event to receive progress updates.
    /// </summary>
    /// <param name="downloadUrl">The URL of the file to download.</param>
    /// <returns>A task that represents the asynchronous download operation.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public async Task DownloadAsync(String downloadUrl)
    {
        var fileName = PathHelper.getFilenameFromUrl(downloadUrl);
        await DownloadAsync(downloadUrl, fileName);
    }
    
    /// <summary>
    /// Downloads a file from the specified URL asynchronously with a custom filename.
    /// Subscribe to ProgressChanged event to receive progress updates.
    /// </summary>
    /// <param name="downloadUrl">The URL of the file to download.</param>
    /// <param name="fileName">The custom filename to use for the downloaded file.</param>
    /// <returns>A task that represents the asynchronous download operation.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public async Task DownloadAsync(String downloadUrl, String fileName)
    {
        var outputPath = Path.Combine(_filePath, fileName);
        
        using var response = await _httpClient.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        var totalBytes = response.Content.Headers.ContentLength;
        
        using var contentStream = await response.Content.ReadAsStreamAsync();
        using var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true);
        
        var buffer = new byte[81920];
        long totalBytesRead = 0;
        int bytesRead;

        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            await fileStream.WriteAsync(buffer, 0, bytesRead);
            totalBytesRead += bytesRead;

            if (totalBytes.HasValue)
            {
                double percentage = (double)totalBytesRead / totalBytes.Value * 100;
                ProgressChanged?.Invoke(this, percentage);
            }
        }
    }
}