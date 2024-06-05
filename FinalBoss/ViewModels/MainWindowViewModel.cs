using FinalBoss.Service;
using FinalBoss.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinalBoss.ViewModels;

public class MainWindowViewModel : ViewModel , INotifyPropertyChanged
{
    private Page? currentPage;

    public Page? CurrentPage
    {
        get => currentPage;
        set { currentPage = value!; OnPropertyChanged(); }
    }

    private readonly INavigationService navigationService;

    public MainWindowViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;

        //-----------------------------------------------------
        currentPage = App.MainContainer.GetInstance<LogOrRegPage>();
        currentPage.DataContext = App.MainContainer.GetInstance<LogOrRegPageModel>();      
        //-----------------------------------------------------
    }






    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------


}
