using GalaSoft.MvvmLight.Messaging;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModels
{
    public class WszystkieEventyViewModel : WszystkieViewModel<Wydarzenia>
    {
          public  WszystkieEventyViewModel():base("Wydarzenia") {

           
            }
        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<Wydarzenia>
                (
                   zarzadanieProjektami2Entities.Wydarzenia.ToList()
                );
        }



        #endregion
        private Wydarzenia _SelectedEvent;
        public Wydarzenia SelectedEvent
        {
            get
            {
                return _SelectedEvent;
            }
            set
            {

                _SelectedEvent = value;
                Messenger.Default.Send(_SelectedEvent);
                OnRequestClose();
            }
        }
       
    }
    }
