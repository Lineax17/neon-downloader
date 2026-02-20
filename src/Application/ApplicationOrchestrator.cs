using Core;

namespace Application;

public class ApplicationOrchestrator
{
    private HostValidator _hostValidator;

    public ApplicationOrchestrator(
        DownloadFileCommand command,
        IDownloadProgressReporter? reporter = null)
    {
        _hostValidator = new HostValidator(command.Url);
    }
    
    public async Task<DownloadResult> StartAsync(
        DownloadFileCommand command,
        IDownloadProgressReporter? reporter = null)
    {
        
        if (_hostValidator.HostIsYoutube(command.Url))
        {
            return new DownloadResult
            {
                Success = false,
                ErrorMessage = "YouTube Downloads are currently not supported. Please use a different URL."
            };
        }
        else
        {
            var downloader = new Core.Download();
            var useCase = new DownloadFileUseCase(downloader);
            return await useCase.ExecuteAsync(command, reporter);
        }
        
    }
}