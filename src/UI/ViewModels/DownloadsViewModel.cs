using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DownloadApp;
using UI.Models;
using UI.Reporting;

namespace UI.ViewModels;

public class DownloadsViewModel : ViewModelBase
{
    private readonly ApplicationOrchestrator _orchestrator = new();

    public ObservableCollection<DownloadItem> Items { get; } = new();

    public async Task StartDownloadAsync(UrlItem item)
    {
        var downloadItem = new DownloadItem(item.Id, item.Url);
        Items.Add(downloadItem);

        var reporter = new DownloadProgressReporter(downloadItem);
        var command = new DownloadFileCommand
        {
            Url = item.Url,
            Reporter = reporter
        };

        try
        {
            downloadItem.Status = "Downloading";
            var result = await _orchestrator.StartAsync(command);
            downloadItem.Status = result.Success ? "Done" : "Error";
            downloadItem.ErrorMessage = result.Success ? null : result.ErrorMessage;
            if (result.Success)
            {
                downloadItem.Progress = 100;
            }
        }
        catch (Exception ex)
        {
            downloadItem.Status = "Error";
            downloadItem.ErrorMessage = ex.Message;
        }
    }
}