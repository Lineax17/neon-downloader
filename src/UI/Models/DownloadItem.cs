using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UI.Models;

public partial class DownloadItem : ObservableObject
{
    public Guid Id { get; }
    public string Url { get; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(StatusColor))]
    private double _progress;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(StatusColor))]
    private string _status;

    [ObservableProperty] private string? _errorMessage;

    public DownloadItem(Guid id, string url)
    {
        Id = id;
        Url = url;
        _status = "Queued";
    }

    public string StatusColor => Status switch
    {
        "Downloading" => "#4CC2FF",
        "Done" => "#4CAF50",
        "Error" => "#F44336",
        _ => "#A0A0A0"
    };
}