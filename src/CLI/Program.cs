using System.CommandLine;

// Entry point for the Neon Downloader CLI application.

var cli = new CLI.CLI();
var rootCommand = cli.CreateRootCommand();
return await rootCommand.InvokeAsync(args);