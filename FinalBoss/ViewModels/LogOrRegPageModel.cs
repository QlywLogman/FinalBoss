using FinalBoss.Commands;
using FinalBoss.Service;
using FinalBoss.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace FinalBoss.ViewModels
{
    public class LogOrRegPageModel : ViewModel, INotifyPropertyChanged
    {
        private Page? currentPage;

        public Page? CurrentPage
        {
            get => currentPage;
            set { currentPage = value; OnPropertyChanged(); }
        }

        private readonly INavigationService navigationService;
        public RelayCommand RegisterOpenCommand { get; }

        public LogOrRegPageModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            RegisterOpenCommand = new(RegOpen);
        }

        private void RegOpen(object? obj)
        {
            //-----------------------------------------------------
            navigationService.Navigate<RegisterPage, RegisterPageViewModel>();
            //-----------------------------------------------------
        }

        //-----------------------------------------------------
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
        //-----------------------------------------------------
    }
}
