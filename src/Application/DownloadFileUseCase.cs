namespace Application;

using Core;

/// <summary>
/// Use case for downloading files from a URL.
/// </summary>
public sealed class DownloadFileUseCase
{
    private readonly Download _downloader;

    /// <summary>
    /// Initializes a new instance of the <see cref="DownloadFileUseCase"/> class.
    /// </summary>
    /// <param name="downloader">The downloader instance to use for downloading files.</param>
    public DownloadFileUseCase(Download downloader)
    {
        _downloader = downloader;
    }

    /// <summary>
    /// Executes the file download operation asynchronously.
    /// </summary>
    /// <param name="command">The download command containing the URL, optional file name, and optional progress reporter.</param>
    /// <returns>A <see cref="DownloadResult"/> indicating the success or failure of the operation.</returns>
    public async Task<DownloadResult> ExecuteAsync(DownloadFileCommand command)
    {
        var reporter = command.Reporter;
        
        _downloader.ProgressChanged += (sender, percentage) => { reporter?.ReportProgress(percentage); };

        if (string.IsNullOrEmpty(command.FileName))
        {
            await _downloader.DownloadAsync(command.Url);
        }
        else
        {
            await _downloader.DownloadAsync(command.Url, command.FileName);
        }

        return new DownloadResult
        {
            Success = true,
        };
    }
}