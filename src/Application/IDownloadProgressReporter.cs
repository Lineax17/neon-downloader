namespace Application;

/// <summary>
/// Defines methods for reporting download progress and status updates.
/// </summary>
public interface IDownloadProgressReporter
{
    /// <summary>
    /// Reports the current download progress as a percentage.
    /// </summary>
    /// <param name="percentage">The current download progress percentage (0-100).</param>
    /// <returns>The reported percentage value.</returns>
    double ReportProgress(double percentage);
    
    /// <summary>
    /// Reports a status message about the download operation.
    /// </summary>
    /// <param name="message">The status message to report.</param>
    /// <returns>The reported status message.</returns>
    String ReportStatus(String message);
}