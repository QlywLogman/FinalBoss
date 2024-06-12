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
    public class LookNotficationViewModel : ViewModel, INotifyPropertyChanged
    {
        public AppDbCountextNotfication appDbCountextNotfication { get; set; }

        private Page? currentPage;

        public Page? CurrentPage
        {
            get => currentPage;
            set { currentPage = value; OnPropertyChanged(); }
        }

        private readonly INavigationService navigationService;
        public RelayCommand ShowNotfications { get; set; }
        public RelayCommand LookVacansiaBack { get; set; }

        public LookNotficationViewModel(INavigationService navigationService, AppDbCountextNotfication appDbCountextNotfication)
        {
            this.navigationService = navigationService;
            ShowNotfications = new(ShowNot);
            LookVacansiaBack = new(LookVacBack);
            AppDbCountextNotfication appDbCountextNotfication1;
        }

        private void ShowNot(object? obj)
        {

        }

        private void LookVacBack(object? obj)
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
