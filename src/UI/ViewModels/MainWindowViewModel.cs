using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UI.Views;

namespace UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentPage;
    
    public MainWindowViewModel()
    {
        _currentPage = new DownloadsViewModel();
    }
    
    [RelayCommand]    
    private async Task AddUrl()
    {
        Console.WriteLine("AddUrl Button was pressed.");
        var dialog = new AddUrlWindow();
        var mainWindow = App.Current?.ApplicationLifetime is
            Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.MainWindow : null;

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
        CurrentPage = new LinkgrabberViewModel();
    }
}