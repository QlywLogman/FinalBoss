using FinalBoss.Commands;
using FinalBoss.Data;
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
    public class DeleteVacansiaViewModel : ViewModel, INotifyPropertyChanged
    {
        public AppDbCountextVacansia AppDbCountextVacansia = new AppDbCountextVacansia();

        private Page? currentPage;
        private string name;

        public Page? CurrentPage
        {
            get => currentPage;
            set { currentPage = value; OnPropertyChanged(); }
        }
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }

        private readonly INavigationService navigationService;
        public RelayCommand VacansiaDelete { get; set; }
        public RelayCommand CreateVacansiaGo { get; set; }
        public RelayCommand LookCvGo { get; set; }

        public DeleteVacansiaViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            VacansiaDelete = new(Delete);
            CreateVacansiaGo = new(VacansiaBack);
            LookCvGo = new(LookCv);
        }

        private void Delete(object? obj)
        {
            var vacansia = AppDbCountextVacansia.Items.FirstOrDefault(n => n.Name == Name);

            if (vacansia != null)
            {
                AppDbCountextVacansia.RemoveItemt(vacansia); 
                AppDbCountextVacansia.SaveChanges();

                Name = "";
            }
        }

        private void VacansiaBack(object? obj)
        {
            //-----------------------------------------------------
            navigationService.Navigate<EmployerVacansiaPage, EmployerVacansiaViewModel>();
            //-----------------------------------------------------
        }

        private void LookCv(object? obj)
        {
            //-----------------------------------------------------
            navigationService.Navigate<LookCvPage, LookCvViewModel>();
            //-----------------------------------------------------
        }


        //-----------------------------------------------------
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
        //-----------------------------------------------------
    }
}
