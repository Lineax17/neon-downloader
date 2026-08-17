using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using UI.Models;

namespace UI.ViewModels;

public partial class LinkgrabberViewModel : ViewModelBase
{
    private readonly LinkQueueState _linkQueueState;
    private readonly DownloadsViewModel _downloadsViewModel;

    public ReadOnlyObservableCollection<UrlItem> Items => _linkQueueState.Items;

    public LinkgrabberViewModel(LinkQueueState linkQueueState, DownloadsViewModel downloadsViewModel)
    {
        _linkQueueState = linkQueueState;
        _downloadsViewModel = downloadsViewModel;
    }

    [RelayCommand]
    private void Delete(Guid id)
    {
        _linkQueueState.Remove(id);
    }

    [RelayCommand]
    private async Task StartDownload(UrlItem? item)
    {
        if (item is null)
            return;

        _linkQueueState.Remove(item.Id);
        await _downloadsViewModel.StartDownloadAsync(item);
    }

    [RelayCommand]
    private async Task StartAllDownloads()
    {
        foreach (var item in _linkQueueState.Items.ToList())
        {
            await StartDownload(item);
        }
    }
}