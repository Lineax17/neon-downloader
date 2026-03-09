using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using UI.Views;

namespace UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
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
}