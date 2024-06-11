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
    public class WorkerCvViewModel : ViewModel, INotifyPropertyChanged
    {
        public AppDbCountextCv AppDbCountextCv = new AppDbCountextCv();

        private Page? currentPage;
        private string name;
        private string field;
        private string univerted;
        private string languages;
        private string dawn;
        private string phone;

        public Page? CurrentPage
        {
            get => currentPage;
            set { currentPage = value; OnPropertyChanged(); }
        }
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public string Field { get => field; set { field = value; OnPropertyChanged(); } }
        public string Univerted { get => univerted; set { univerted = value; OnPropertyChanged(); } }
        public string Languages { get => languages; set { languages = value; OnPropertyChanged(); } }
        public string Dawn { get => dawn; set { dawn = value; OnPropertyChanged(); } }
        public string Phone { get => phone; set { name = value; OnPropertyChanged(); } }

        private readonly INavigationService navigationService;
        public RelayCommand CrateCv { get; set; }
        public RelayCommand CvDeleteGo { get; set; }
        public RelayCommand logORregGoCv { get; set; }

        public WorkerCvViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            CrateCv = new(AddCv);
            CvDeleteGo = new(GoDeleteCv);
            logORregGoCv = new(GoLoOrReCv);
        }

        private void AddCv(object? obj)
        {
            var Cv = new CVclass()
            {
                Name = Name,
                Field = Field,
                Univerted = Univerted,
                Languages = Languages,
                Dawn = Dawn,
                Phone = Phone,
            };
            AppDbCountextCv.AddItem(Cv);
            AppDbCountextCv.SaveChanges();

            Name = "";
            Field = "";
            Univerted = "";
            Languages = "";
            Dawn = "";
            Phone = "";
        }

        private void GoDeleteCv(object? obj)
        {
            //-----------------------------------------------------
            navigationService.Navigate<DeleteCvPage, DeleteCvViewModel>();
            //-----------------------------------------------------
        }

        private void GoLoOrReCv(object? obj)
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
