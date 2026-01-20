namespace Application;
using Core;
public sealed class DownloadFileUseCase
{
    private readonly Download _downloader;

    public DownloadFileUseCase(Download downloader)
    {
        _downloader = downloader;
    }

    public async Task<DownloadResult> ExecuteAsync(
        DownloadFileCommand command,
        IProgress<double>? progress = null)
    {
        _downloader.ProgressChanged += (sender, percentage) =>
        {
            progress?.Report(percentage);
        };
        
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