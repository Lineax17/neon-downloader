using Avalonia.Threading;
using DownloadApp;
using UI.Models;

namespace UI.Reporting;

/// <summary>
/// Reports download progress and status to the underlying UI item.
/// All updates are marshalled to the UI thread.
/// </summary>
public sealed class DownloadProgressReporter : IDownloadProgressReporter
{
    private readonly DownloadItem _item;

    public DownloadProgressReporter(DownloadItem item)
    {
        _item = item;
    }

    public double ReportProgress(double percentage)
    {
        Dispatcher.UIThread.Post(() => _item.Progress = percentage);
        return percentage;
    }

    public string ReportStatus(string message)
    {
        Dispatcher.UIThread.Post(() => _item.Status = message);
        return message;
    }
}