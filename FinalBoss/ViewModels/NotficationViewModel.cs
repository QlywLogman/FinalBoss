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
using System.Xml.Linq;

namespace FinalBoss.ViewModels
{
    public class NotficationViewModel : ViewModel, INotifyPropertyChanged
    {

        public AppDbCountextNotfication NotficationDbCountext = new AppDbCountextNotfication();

        private Page? currentPage;
        private string cvName;
        private string message;
        private string date;

        public Page? CurrentPage
        {
            get => currentPage;
            set { currentPage = value; OnPropertyChanged(); }
        }
        public string CvName { get => cvName; set { cvName = value; OnPropertyChanged(); } }
        public string Message { get => message; set { message = value; OnPropertyChanged(); } }
        public string Date { get => date; set { date = value; OnPropertyChanged(); } }

        private readonly INavigationService navigationService;
        public RelayCommand SendNotfication { get; set; }
        public RelayCommand LookCvBack { get; set; }

        public NotficationViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            SendNotfication = new(CreateNot);
            LookCvBack = new(LokCvBck);
        }

        private void CreateNot(object? obj)
        {
            var notfication = new Notfication()
            {
                CvName = cvName,
                Message = message,
                Date = date,
            };
            NotficationDbCountext.AddItem(notfication);
            NotficationDbCountext.SaveChanges();

            CvName = "";
            Message = "";
            Date = "";
        }

        private void LokCvBck(object? obj)
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
