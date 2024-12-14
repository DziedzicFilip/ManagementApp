using CommunityToolkit.Mvvm.Input;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectManagementApp.ViewModels
{
    public  class WybierzEventViewModel : WorkspaceViewModel
    {
        public ICommand OpenZadania { get; set; }
        public ICommand OpenNotatki { get; set; }


        public WybierzEventViewModel()
        {
            base.DisplayName = "Wybierz Event";

            
            OpenNotatki = new RelayCommand(OpenNotatkiWindow);
     
            OpenZadania = new RelayCommand(OpenZadaniaWindow);
          
        }
        private int _eventID;
        public int EventID
        {
            get { return _eventID; }
            set
            {
                _eventID = value;
                OnPropertyChanged(() => EventID);
            }
        }
        public void OpenNotatkiWindow()
        {
           
            var notatkiWindow = new NotatkiWindowEventView(EventID);  
            notatkiWindow.Show();
        }
        public void OpenZadaniaWindow()
        {
          
            var zadaniaWindow = new ZadaniaWindowEventView(EventID);  
           zadaniaWindow.Show();
        }
    }
}
