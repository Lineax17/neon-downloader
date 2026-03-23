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

    [ObservableProperty] private ViewModelBase _currentPage;

    public MainWindowViewModel()
    {
        _currentPage = new DownloadsViewModel();
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
        CurrentPage = new DownloadsViewModel();
    }

    [RelayCommand]
    private void NavigateToLinkgrabber()
    {
        CurrentPage = new LinkgrabberViewModel(_linkQueueState);
    }
}