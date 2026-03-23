using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UI.ViewModels;

public partial class AddUrlWindowViewModel : ViewModelBase
{
    private readonly LinkQueueState _linkQueueState;
    
    public AddUrlWindowViewModel(LinkQueueState linkQueueState)
    {
        _linkQueueState = linkQueueState;
    }
    
    [ObservableProperty]
    private string _url = string.Empty;

    [RelayCommand]
    private void Confirm()
    {
        Console.WriteLine("Entered URL: " + Url);

        if (_linkQueueState.TryEnqueue(Url))
        {
            Url = string.Empty;
        }
    }
}