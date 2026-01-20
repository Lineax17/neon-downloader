namespace Application;

/// <summary>
/// Represents the result of a file download operation.
/// </summary>
public sealed record DownloadResult
{
    /// <summary>
    /// Gets a value indicating whether the download operation was successful.
    /// </summary>
    public required bool Success { get; init; }
    
    /// <summary>
    /// Gets the error message if the download operation failed.
    /// </summary>
    public string? ErrorMessage { get; init; }
}
