# CLI Module

This module provides command-line interface (CLI) functionalities 
for the application. It allows users to interact with the application 
through terminal commands.

## Features

## Usage

To run the application with a specific URL, use the following command:

```
dotnet run -- --url "https://dl.fedoraproject.org/pub/fedora/linux/releases/43/KDE/x86_64/iso/Fedora-KDE-Desktop-Live-43-1.6.x86_64.iso"
```

To asign a custom name to the download, use the `--name` option:

```
dotnet run -- --url "https://dl.fedoraproject.org/pub/fedora/linux/releases/43/KDE/x86_64/iso/Fedora-KDE-Desktop-Live-43-1.6.x86_64.iso" --name "FedoraKDE.iso"
```