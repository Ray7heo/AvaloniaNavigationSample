using System;
using System.Collections.Generic;
using AvaloniaNavigationSample.ViewModels;

namespace AvaloniaNavigationSample.Services.Navigation;

public interface INavigationService
{
    Stack<ViewModelBase> NavigationStack { get; }

    object? Parameter { get;  set; }

    event Action? CurrentViewModelChanged;

    ViewModelBase? CurrentViewModel { get; }

    public void Push<T>() where T : ViewModelBase;

    public void Push<T>(object parameter) where T : ViewModelBase;

    public void Back();

    public void Replace<T>() where T : ViewModelBase;

    public void Replace<T>(object parameter) where T : ViewModelBase;
}