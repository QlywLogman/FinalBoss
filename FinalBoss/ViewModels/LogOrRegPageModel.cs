using FinalBoss.Commands;
using FinalBoss.Data;
using FinalBoss.Service;
using FinalBoss.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace FinalBoss.ViewModels
{
    public class LogOrRegPageModel : ViewModel, INotifyPropertyChanged
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        private Page? currentPage;
        private string name;
        private string password;
        private bool isSelectedEmployer;
        private bool isSelectedWorker;

        public Page? CurrentPage
        {
            get => currentPage;
            set { currentPage = value; OnPropertyChanged(); }
        }
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        public bool IsSelectedEmployer { get => isSelectedEmployer; set { isSelectedEmployer = value; OnPropertyChanged(); } }
        public bool IsSelectedWorker { get => isSelectedWorker; set { isSelectedWorker = value; OnPropertyChanged(); } }

        private readonly INavigationService navigationService;
        public RelayCommand RegisterOpenCommand { get; }
        public RelayCommand LogInCommand { get; }

        public LogOrRegPageModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            RegisterOpenCommand = new(RegOpen);
            LogInCommand = new(LogIn);

        }

        private void LogIn(object? obj)
        {

            var accessMode = (IsSelectedEmployer ? "Employer" : "Worker");
            var user = appDbContext.Items.FirstOrDefault(n => n.Name == Name && n.Password == Password && n.AccessMode == accessMode);
            if (user != null)
            {
                if (accessMode == "Worker")
                {
                    IsSelectedEmployer = false;
                    IsSelectedWorker = false;
                    navigationService.Navigate<WorkerCvPage, WorkerCvViewModel>();
                }
                if (accessMode == "Employer")
                {
                    Name = "";
                    Password = "";
                    IsSelectedEmployer = false;
                    IsSelectedWorker = false;
                    navigationService.Navigate<EmployerVacansiaPage, EmployerVacansiaViewModel>();
                }
            }
            else
            {
                MessageBox.Show("User not found or incorrect credentials");
            }
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
