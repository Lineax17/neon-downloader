using System.CommandLine;

var cli = new CLI.CLI();
var rootCommand = cli.CreateRootCommand();
return await rootCommand.InvokeAsync(args);