using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using AvaloniaNavigationSample.ViewModels;

namespace AvaloniaNavigationSample.Services.Navigation;

public class DefaultNavigationService : INavigationService
{
    public Stack<ViewModelBase> NavigationStack { get; } = new();

    public object? Parameter { get; set; }

    private ViewModelBase? _currentViewModel;

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        private set
        {
            _currentViewModel = value;
            CurrentViewModelChanged?.Invoke();
        }
    }

    public event Action? CurrentViewModelChanged;

    public void Push<T>() where T : ViewModelBase
    {
        Parameter = null;
        NavigationStack.Push(App.Services.GetRequiredService<T>());
        CurrentViewModel = NavigationStack.Peek();
    }

    public void Push<T>(object parameter) where T : ViewModelBase
    {
        Parameter = parameter;
        NavigationStack.Push(App.Services.GetRequiredService<T>());
        CurrentViewModel = NavigationStack.Peek();
    }

    public void Back()
    {
        if (NavigationStack.Count > 1)
        {
            NavigationStack.Pop();
        }

        CurrentViewModel = NavigationStack.Peek();
    }

    public void Replace<T>() where T : ViewModelBase
    {
        Parameter = null;
        NavigationStack.Pop();
        NavigationStack.Push(App.Services.GetRequiredService<T>());
        CurrentViewModel = NavigationStack.Peek();
    }

    public void Replace<T>(object parameter) where T : ViewModelBase
    {
        Parameter = parameter;
        NavigationStack.Pop();
        NavigationStack.Push(App.Services.GetRequiredService<T>());
        CurrentViewModel = NavigationStack.Peek();
    }
}