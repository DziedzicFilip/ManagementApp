using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Helper;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ProjectManagementApp.Views;
using GalaSoft.MvvmLight.Messaging;

namespace ProjectManagementApp.ViewModels
{
    public class WszystkieProjektyViewModel : WszystkieViewModel<Projekty>
    {
        #region Constructor
        public WszystkieProjektyViewModel()
            : base("Projekty")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Projekty>
            (
                zarzadanieProjektami2Entities.Projekty.ToList()
            );
        }


        #endregion
        #region DoDopracowania
      
       
        #endregion

        #region Props
        private Projekty _SelectedProjekt;
        public Projekty SelectedProjekt
        {
            get
            {
                return _SelectedProjekt;
            }
            set
            {
                
                _SelectedProjekt = value;
                Messenger.Default.Send(_SelectedProjekt);
                OnRequestClose();
            }
        }


        #endregion
    }
}