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
    public class EmployerVacansiaViewModel : ViewModel, INotifyPropertyChanged
    {
        public AppDbCountextVacansia AppDbCountextVacansia = new AppDbCountextVacansia();

        private Page? currentPage;
        private string name;
        private string title;
        private string salary;
        private string location;
        private string jobType;
        private string contactEmail;


        public Page? CurrentPage
        {
            get => currentPage;
            set { currentPage = value; OnPropertyChanged(); }
        }
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public string Title { get => title; set { title = value; OnPropertyChanged(); } }
        public string Salary { get => salary; set { salary = value; OnPropertyChanged(); } }
        public string Location { get => location; set { location = value; OnPropertyChanged(); } }
        public string JobType { get => jobType; set { jobType = value; OnPropertyChanged(); } }
        public string ContactEmail { get => contactEmail; set { name = value; OnPropertyChanged(); } }

        private readonly INavigationService navigationService;
        public RelayCommand CrateVacansia { get; set; }
        public RelayCommand VacansiaDeleteGo { get; set; }
        public RelayCommand logORregGo { get; set; }

        public EmployerVacansiaViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            CrateVacansia = new(AddVacansia);
            VacansiaDeleteGo = new(GoDelete);
            logORregGo = new(GoLoOrRe);
        }

        private void AddVacansia(object? obj)
        {
            var vacansia = new VacansiaClass() 
            {
                Name = Name,
                Title = Title,
                Salary = Salary,
                Location = Location,
                JobType = JobType,
                ContactEmail = ContactEmail,
            };
            AppDbCountextVacansia.AddItem(vacansia);
            AppDbCountextVacansia.SaveChanges();

            Name = "";
            Title = "";
            Salary = "";
            Location = "";
            JobType = "";
            ContactEmail = "";
        }

        private void GoDelete(object? obj)
        {
            //-----------------------------------------------------
            navigationService.Navigate<DeleteVacansiaPage, DeleteVacansiaViewModel>();
            //-----------------------------------------------------
        }

        private void GoLoOrRe(object? obj)
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
