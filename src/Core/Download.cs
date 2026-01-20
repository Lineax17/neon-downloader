namespace Core;

using System.Net.Http;
using System.IO;

public class Download
{
    private static readonly HttpClient _httpClient = new HttpClient();
    private String _filePath;


    public Download()
    {
        this._filePath = PathHelper.getDownloadDirectory();
        
    }
    
    public Download(String filePath)
    {
        this._filePath = filePath;
    }

    /*
     * 
     */
    public async Task DownloadAsync(String downloadUrl)
    {
        var outputPath = Path.Combine(_filePath, PathHelper.getFilenameFromUrl(downloadUrl));
        
        using var response = await _httpClient.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode(); // Throw if not a success code.
        
        using var fileStream = new FileStream(outputPath, FileMode.Create);
        await response.Content.CopyToAsync(fileStream);
    }
    
    /// <summary>
    /// Downloads a file from the specified URL asynchronously with a custom filename.
    /// </summary>
    /// <param name="downloadUrl">The URL of the file to download.</param>
    /// <param name="fileName">The custom filename to use for the downloaded file.</param>
    /// <returns>A task that represents the asynchronous download operation.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public async Task DownloadAsync(String downloadUrl, String fileName)
    {
        var outputPath = Path.Combine(_filePath, fileName);
        
        using var response = await _httpClient.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode(); // Throw if not a success code.
        
        using var fileStream = new FileStream(outputPath, FileMode.Create);
        await response.Content.CopyToAsync(fileStream);
    }
}