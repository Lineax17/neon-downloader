namespace Application;

public sealed record DownloadFileCommand
{
    public required string Url { get; init; }
    public string? FileName { get; init; }
}