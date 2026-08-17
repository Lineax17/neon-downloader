using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UI.Models;

public partial class DownloadItem : ObservableObject
{
    public Guid Id { get; }
    public string Url { get; }

    [ObservableProperty] private double _progress;
    [ObservableProperty] private string _status;
    [ObservableProperty] private string? _errorMessage;

    public DownloadItem(Guid id, string url)
    {
        Id = id;
        Url = url;
        _status = "Queued";
    }
}