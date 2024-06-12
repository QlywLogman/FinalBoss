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
    public class LookCvViewModel : ViewModel, INotifyPropertyChanged
    {
        public AppDbCountextCv AppDbCountextCv {  get; set; }

        private Page? currentPage;
        public Page? CurrentPage
        {
            get => currentPage;
            set { currentPage = value; OnPropertyChanged(); }
        }

        private readonly INavigationService navigationService;
        public RelayCommand ShowCvs { get; set; }
        public RelayCommand DeleteCanacsiaBack { get; set; }
        public RelayCommand WriteNotfication { get; set; }

        public LookCvViewModel(INavigationService navigationService, AppDbCountextCv appDbCountextCv)
        {
            this.navigationService = navigationService;
            ShowCvs = new(Show);
            DeleteCanacsiaBack = new(DeleteVacansiaBack);
            WriteNotfication = new(WriteNot);
            AppDbCountextCv = appDbCountextCv;
        }

        private void Show(object? obj)
        {

        }

        private void DeleteVacansiaBack(object? obj)
        {
            //-----------------------------------------------------
            navigationService.Navigate<DeleteVacansiaPage, DeleteVacansiaViewModel>();
            //-----------------------------------------------------
        }

        private void WriteNot(object? obj)
        {
            //-----------------------------------------------------
            navigationService.Navigate<NotficationPage, NotficationViewModel>();
            //-----------------------------------------------------
        }



        //-----------------------------------------------------
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
        //-----------------------------------------------------
    }
}
