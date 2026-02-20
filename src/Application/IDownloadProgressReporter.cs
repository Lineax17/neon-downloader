namespace Application;

public interface IDownloadProgressReporter
{
    double ReportProgress(double percentage);
    
    String ReportStatus(String message);
}