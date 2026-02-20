using Core;

namespace Application;

/// <summary>
/// Orchestrates download operations with host validation and queue management.
/// Provides both direct download functionality for CLI and queue-based downloads for GUI.
/// </summary>
public class ApplicationOrchestrator
{
    private readonly HostValidator _hostValidator;
    private readonly DownloadQueue _downloadQueue;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationOrchestrator"/> class.
    /// </summary>
    public ApplicationOrchestrator()
    {
        _hostValidator = new HostValidator();
        _downloadQueue = new DownloadQueue();
    }
    
    /// <summary>
    /// Starts a direct download operation for the specified command.
    /// Validates the host and executes the download using the progress reporter from the command.
    /// </summary>
    /// <param name="command">The download command containing the URL, optional file name, and optional progress reporter.</param>
    /// <returns>A <see cref="DownloadResult"/> indicating the success or failure of the download operation.</returns>
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
    
    /// <summary>
    /// Processes and downloads all items currently in the download queue.
    /// Each download is executed sequentially with host validation.
    /// </summary>
    /// <returns>A list of <see cref="DownloadResult"/> objects, one for each queued download.</returns>
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
    
    /// <summary>
    /// Adds a download command to the queue for later processing.
    /// Use <see cref="DownloadItemsInQueue"/> to process all queued downloads.
    /// </summary>
    /// <param name="command">The download command to add to the queue.</param>
    public void EnqueueDownload(DownloadFileCommand command)
    {
        _downloadQueue.Enqueue(command);
    }
}