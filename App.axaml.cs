using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using AvaloniaNavigationSample.Services.Navigation;
using AvaloniaNavigationSample.ViewModels;
using AvaloniaNavigationSample.Views;

namespace AvaloniaNavigationSample;

public class App : Application
{
    // public new static App Current => (App)Application.Current;

    public static IServiceProvider Services { get; } = ConfigureServices();

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<MainWindow>();

        services.AddSingleton<INavigationService, DefaultNavigationService>();

        services.AddTransient<DetailViewModel>();
        services.AddTransient<DetailView>();

        services.AddTransient<HomeViewModel>();
        services.AddTransient<HomeView>();

        return services.BuildServiceProvider();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            BindingPlugins.DataValidators.RemoveAt(0);
            desktop.MainWindow = Services.GetRequiredService<MainWindow>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}