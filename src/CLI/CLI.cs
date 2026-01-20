using System.CommandLine;
using Application;

namespace CLI;

public sealed class CLI
{
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
            var command = new DownloadFileCommand
            {
                Url = url,
                FileName = fileName
            };

            var downloader = new Core.Download();
            var useCase = new DownloadFileUseCase(downloader);
            var progress = new Progress<double>(p => Console.Write($"\rDownload: {p:F1}%"));
            var result = await useCase.ExecuteAsync(command, progress);
            
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