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
    public class DeleteCvViewModel : ViewModel, INotifyPropertyChanged
    {
        public AppDbCountextCv AppDbCountextCv = new AppDbCountextCv();

        private Page? currentPage;
        private string name;

        public Page? CurrentPage
        {
            get => currentPage;
            set { currentPage = value; OnPropertyChanged(); }
        }

        public string Name { get => name; set { name = value; OnPropertyChanged(); } }

        private readonly INavigationService navigationService;
        public RelayCommand CvDelete { get; set; }
        public RelayCommand CreateCvGo { get; set; }
        public RelayCommand LookVacansiaGo { get; set; }

        public DeleteCvViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            CvDelete = new(DeleteCv);
            CreateCvGo = new(CvBack);
            LookVacansiaGo = new(LookVacansia);
        }

        private void DeleteCv(object? obj)
        {
            var Cv = AppDbCountextCv.Items.FirstOrDefault(n => n.Name == Name);

            if (Cv != null)
            {
                AppDbCountextCv.RemoveItemt(Cv);
                AppDbCountextCv.SaveChanges();

                Name = "";
            }
        }

        private void CvBack(object? obj)
        {
            //-----------------------------------------------------
            navigationService.Navigate<WorkerCvPage, WorkerCvViewModel>();
            //-----------------------------------------------------
        }

        private void LookVacansia(object? obj)
        {
            //-----------------------------------------------------
            navigationService.Navigate<LookAtVacansia, LookAtVacansiaViewModel>();
            //-----------------------------------------------------
        }

        //-----------------------------------------------------
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
        //-----------------------------------------------------
    }
}
