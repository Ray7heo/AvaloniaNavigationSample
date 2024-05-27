using CommunityToolkit.Mvvm.Input;
using AvaloniaNavigationSample.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaNavigationSample.ViewModels;

public partial class DetailViewModel(INavigationService navigationService) : ViewModelBase
{
    [ObservableProperty] private string _parameter = navigationService.Parameter as string ?? "Null";

    [RelayCommand]
    public void NavigateBack()
    {
        navigationService.Back();
    }

    [RelayCommand]
    public void NavigateNext()
    {
        navigationService.Push<DetailViewModel>();
    }

    [RelayCommand]
    public void Replace()
    {
       navigationService.Replace<DetailViewModel>();
    }
}