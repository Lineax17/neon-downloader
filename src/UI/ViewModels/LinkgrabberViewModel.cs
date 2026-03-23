using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using UI.Models;

namespace UI.ViewModels;

public partial class LinkgrabberViewModel : ViewModelBase
{
    private readonly LinkQueueState _linkQueueState;

    public ReadOnlyObservableCollection<UrlItem> Items => _linkQueueState.Items;

    public LinkgrabberViewModel(LinkQueueState linkQueueState)
    {
        _linkQueueState = linkQueueState;
    }

    [RelayCommand]
    private void Delete(Guid id)
    {
        _linkQueueState.Remove(id);
    }

    [RelayCommand]
    private void StartDownload(UrlItem? item)
    {
        // Placeholder for single-item download start.
    }

    [RelayCommand]
    private void StartAllDownloads()
    {
        // Placeholder for batch download start.
    }
}