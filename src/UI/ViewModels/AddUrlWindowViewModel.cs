using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UI.ViewModels;

public partial class AddUrlWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _url = string.Empty;

    [RelayCommand]
    private void Confirm()
    {
        // Logic to handle the URL confirmation
        Console.WriteLine("Entered URL: " + Url);
    }
}