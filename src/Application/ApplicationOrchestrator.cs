using Core;

namespace Application;

public class ApplicationOrchestrator
{
    private readonly HostValidator _hostValidator;
    private readonly DownloadQueue _downloadQueue;

    public ApplicationOrchestrator()
    {
        _hostValidator = new HostValidator();
        _downloadQueue = new DownloadQueue();
    }
    
    public async Task<DownloadResult> StartAsync(DownloadFileCommand command)
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
            return await useCase.ExecuteAsync(command);
        }
    }
    
    public async Task<List<DownloadResult>> DownloadItemsInQueue()
    {
        var results = new List<DownloadResult>();
        
        while (_downloadQueue.Count > 0)
        {
            var command = _downloadQueue.Dequeue();
            var result = await StartAsync(command);
            results.Add(result);
        }
        
        return results;
    }
    
    public void EnqueueDownload(DownloadFileCommand command)
    {
        _downloadQueue.Enqueue(command);
    }
}