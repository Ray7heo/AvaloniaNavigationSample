using CommunityToolkit.Mvvm.ComponentModel;
using AvaloniaNavigationSample.Services.Navigation;

namespace AvaloniaNavigationSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ViewModelBase? _currentViewModel;

    [ObservableProperty] private string _navigationStackCount = "0";

    public MainWindowViewModel(INavigationService navigationService)
    {
        navigationService.CurrentViewModelChanged += () =>
        {
            CurrentViewModel = navigationService.CurrentViewModel;
            NavigationStackCount = navigationService.NavigationStack.Count.ToString();
        };
        navigationService.Push<HomeViewModel>();
    }
}