namespace Application;

/// <summary>
/// Represents a command to download a file from a URL.
/// </summary>
public sealed record DownloadFileCommand
{
    /// <summary>
    /// Gets the URL of the file to download.
    /// </summary>
    public required string Url { get; init; }
    
    /// <summary>
    /// Gets the optional file name for the downloaded file.
    /// If not specified, the file name will be extracted from the URL.
    /// </summary>
    public string? FileName { get; init; }
}