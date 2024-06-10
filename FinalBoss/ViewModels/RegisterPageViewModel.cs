using FinalBoss.Commands;
using FinalBoss.Data;
using FinalBoss.Models.Context;
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

namespace FinalBoss.ViewModels
{
    public class RegisterPageViewModel : ViewModel, INotifyPropertyChanged
    {
        public AppDbContext appDbContext = new AppDbContext();

        private Page? currentPage;
        private string name;
        private string surname;
        private string gmail;
        private string password;
        private int age;
        private bool isSelectedEmployer;
        private bool isSelectedWorker;

        public Page? CurrentPage
        {
            get => currentPage;
            set { currentPage = value; OnPropertyChanged(); }
        }
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public string Surname { get => surname; set { surname = value; OnPropertyChanged(); } }
        public string Gmail { get => gmail; set { gmail = value; OnPropertyChanged(); } }
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        public int Age { get => age; set { age = value; OnPropertyChanged(); } }
        public bool IsSelectedEmployer { get => isSelectedEmployer; set { isSelectedEmployer = value; OnPropertyChanged(); } }
        public bool IsSelectedWorker { get => isSelectedWorker; set { isSelectedWorker = value; OnPropertyChanged(); } }


        private readonly INavigationService navigationService;
        public RelayCommand WriteRegFile { get; set; }


        public RegisterPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            WriteRegFile = new(Add);
        }

        private void Add(object? obj)
        {
            var Register = new RegisterClass()
            {
                Name = Name,
                Surname = Surname,
                Gmail = Gmail,
                Password = Password,
                Age = Age,
                AccessMode = (IsSelectedEmployer ? "Employer" : "Worker")
            };
            appDbContext.AddItem(Register);
            appDbContext.SaveChanges();

            Name = "";
            Surname = "";
            Gmail = "";
            Password = "";
            Age = 0;
            IsSelectedEmployer = false;
            IsSelectedWorker = false;
        }

        private void RegOpen(object? obj)
        {
            //-----------------------------------------------------
            navigationService.Navigate<LogOrRegPage, LogOrRegPageModel>();
            //-----------------------------------------------------
        }

        //-----------------------------------------------------
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
        //-----------------------------------------------------
    }
}
