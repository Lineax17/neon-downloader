using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UI.Views;

namespace UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly LinkQueueState _linkQueueState = new();
    private readonly DownloadsViewModel _downloadsViewModel = new();
    private readonly LinkgrabberViewModel _linkgrabberViewModel;

    [ObservableProperty] private ViewModelBase _currentPage;

    public MainWindowViewModel()
    {
        _linkgrabberViewModel = new LinkgrabberViewModel(_linkQueueState, _downloadsViewModel);
        _currentPage = _downloadsViewModel;
    }

    [RelayCommand]
    private async Task AddUrl()
    {
        Console.WriteLine("AddUrl Button was pressed.");
        var dialog = new AddUrlWindow
        {
            DataContext = new AddUrlWindowViewModel(_linkQueueState)
        };
        var mainWindow = Application.Current?.ApplicationLifetime is
            IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.MainWindow
            : null;

        if (mainWindow is null)
        {
            dialog.Show();
            return;
        }

        await dialog.ShowDialog(mainWindow);
    }

    [RelayCommand]
    private void NavigateToDownloads()
    {
        CurrentPage = _downloadsViewModel;
    }

    [RelayCommand]
    private void NavigateToLinkgrabber()
    {
        CurrentPage = _linkgrabberViewModel;
    }
}