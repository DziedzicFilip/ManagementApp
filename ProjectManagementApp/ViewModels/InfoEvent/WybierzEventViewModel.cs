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
      
    }
}
