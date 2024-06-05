using FinalBoss.Data;
using FinalBoss.Models.Abstrac;
using FinalBoss.Models.Context;
using FinalBoss.Service;
using FinalBoss.ViewModels;
using FinalBoss.Views;
using SimpleInjector;
using System;
using System.Configuration;
using System.Data;
using System.Windows;

namespace FinalBoss;


public partial class App : Application
{
    public static Container MainContainer { get; set; } = new();
    public App()
    {
        AddOtherServices();
        AddViews();
        AddViewModels();
    }

    private void AddOtherServices()
    {
        MainContainer.RegisterSingleton<AppDbContext>();
        MainContainer.RegisterSingleton<INavigationService, NavigationService>();
    }

    private void AddViewModels()
    {
        MainContainer.RegisterSingleton<MainWindowViewModel>();
        MainContainer.RegisterSingleton<LogOrRegPageModel>();

    }

    private void AddViews()
    {
        MainContainer.RegisterSingleton<MainWindow>();
        MainContainer.RegisterSingleton<LogOrRegPage>();

    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainView = MainContainer.GetInstance<MainWindow>();
        mainView.DataContext = MainContainer.GetInstance<MainWindowViewModel>();
        mainView.Show();
        base.OnStartup(e);
    }
}
