using System.CommandLine;
using Application;

namespace CLI;

public sealed class CLI
{
    /// <summary>
    /// Creates and configures the root command for the Neon Downloader CLI application.
    /// </summary>
    /// <returns>A configured <see cref="RootCommand"/> with URL and file name options.</returns>
    public RootCommand CreateRootCommand()
    {
        var urlOption = new Option<string>(
            name: "--url",
            description: "The URL of the file to download")
        {
            IsRequired = true
        };

        var fileNameOption = new Option<string?>(
            name: "--file-name",
            description: "The name of the downloaded file (optional)");

        var rootCommand = new RootCommand("Neon Downloader - Download files from the internet");
        rootCommand.AddOption(urlOption);
        rootCommand.AddOption(fileNameOption);

        rootCommand.SetHandler(async (url, fileName) =>
        {
            var reporter = new ConsoleProgressReporter();
            
            var command = new DownloadFileCommand
            {
                Url = url,
                FileName = fileName,
                Reporter = reporter
            };

            var orchestrator = new ApplicationOrchestrator();
            var result = await orchestrator.StartAsync(command);
            
            Console.WriteLine();
            if (result.Success)
            {
                Console.WriteLine($"Download erfolgreich");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"Fehler: {result.ErrorMessage}");
                Environment.Exit(1);
            }
        }, urlOption, fileNameOption);

        return rootCommand;
    }
}

/// <summary>
/// Console implementation of the download progress reporter.
/// </summary>
internal sealed class ConsoleProgressReporter : IDownloadProgressReporter
{
    public double ReportProgress(double percentage)
    {
        Console.Write($"\rDownload: {percentage:F1}%");
        return percentage;
    }

    public string ReportStatus(string message)
    {
        Console.WriteLine(message);
        return message;
    }
}
