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
    public class LookAtVacansiaViewModel : ViewModel, INotifyPropertyChanged
    {
        public AppDbCountextVacansia AppDbCountextVacansia { get; set; }

        private Page? currentPage;

        public Page? CurrentPage
        {
            get => currentPage;
            set { currentPage = value; OnPropertyChanged(); }
        }

        private readonly INavigationService navigationService;
        public RelayCommand ShowVacansias { get; set; }
        public RelayCommand DeleteCvBack { get; set; }
        public RelayCommand LookNotfication { get; set; }

        public LookAtVacansiaViewModel(INavigationService navigationService, AppDbCountextVacansia appDbCountextVacansia)
        {
            this.navigationService = navigationService;
            ShowVacansias = new(ShowVac);
            DeleteCvBack = new(DelCvBack);
            LookNotfication = new(LookNot);
            AppDbCountextVacansia = appDbCountextVacansia;
        }

        private void ShowVac(object? obj)
        {

        }

        private void DelCvBack(object? obj)
        {
            //-----------------------------------------------------
            navigationService.Navigate<DeleteCvPage, DeleteCvViewModel>();
            //-----------------------------------------------------
        }

        private void LookNot(object? obj)
        {
            //-----------------------------------------------------
            navigationService.Navigate<LookNotficationPage, LookNotficationViewModel>();
            //-----------------------------------------------------
        }



        //-----------------------------------------------------
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
        //-----------------------------------------------------
    }
}
