namespace Application;

public sealed record DownloadResult
{
    public required bool Success { get; init; }
    public string? ErrorMessage { get; init; }
}
