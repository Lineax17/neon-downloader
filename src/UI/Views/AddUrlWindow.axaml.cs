using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UI.ViewModels;

namespace UI.Views;

public partial class AddUrlWindow : Window
{
    public AddUrlWindow()
    {
        InitializeComponent();
        DataContext = new AddUrlWindowViewModel();
    }
}