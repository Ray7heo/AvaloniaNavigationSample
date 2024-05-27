using CommunityToolkit.Mvvm.Input;
using AvaloniaNavigationSample.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaNavigationSample.ViewModels;

public partial class HomeViewModel(INavigationService navigationService) : ViewModelBase
{
    [ObservableProperty]
    private string _name  = "Home";

    [RelayCommand]
    public void NavigateToDetail()
    {
        navigationService.Push<DetailViewModel>(Name);
    }
}