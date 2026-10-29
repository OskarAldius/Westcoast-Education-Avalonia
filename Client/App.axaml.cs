using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Client.Helpers;
using Client.ViewModels;
using Client.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Client;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Skapa en instans(en copia av en class)
        var collection = new ServiceCollection();

        collection.AddServices();



        var serviceProvider = collection.BuildServiceProvider();

        var vm = serviceProvider.GetRequiredService<MainWindowViewModel>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow()
            {
                // Kopplar på vår ViewModel till vår View
                DataContext = vm

            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}