using Avalonia.Controls;
using AvaloniaNavigationSample.ViewModels;

namespace AvaloniaNavigationSample.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel mainWindowViewModel)
    {
        InitializeComponent();
        DataContext = mainWindowViewModel;
    }
}