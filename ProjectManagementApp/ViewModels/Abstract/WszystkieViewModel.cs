using CommunityToolkit.Mvvm.Input;
using GalaSoft.MvvmLight.Messaging;
using ProjectManagementApp.Helper;
using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectManagementApp.ViewModels
{
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region DB
        protected readonly ZarzadanieProjektami2Entities zarzadanieProjektami2Entities;


        #endregion
        #region Command
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)

                    _LoadCommand = new BaseCommand(() => Load());
                return _LoadCommand;

            }


        }

        private BaseCommand _Dodawania;
        public ICommand DodawaniaCommand
        {
            get
            {
                if (_Dodawania == null)
                    _Dodawania = new BaseCommand(() => Dodaj());
                return _Dodawania;
            }
        }

        #endregion
        #region RefreshCommand
        private BaseCommand _RefreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (_RefreshCommand == null)
                    _RefreshCommand = new BaseCommand(() => Refresh());
                return _RefreshCommand;
            }
        }
        #endregion

        #region OpenNewProjectCommand
        public ICommand OpenNewProjectCommand { get; private set; }
     
        #endregion
        #region List
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                {
                    Load();
                }
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion
        #region Constructor
        public WszystkieViewModel(String displayName)
        {
            zarzadanieProjektami2Entities = new ZarzadanieProjektami2Entities();
            base.DisplayName = displayName;

         
        }
        #endregion
        #region Helpers
        public abstract void Load();
       
        public  void Refresh()
        {
            List.Clear();
            Load();
        }
        public void Dodaj()
        {
            //ShowMessageBox(DisplayName);
            Messenger.Default.Send(DisplayName+"ADD");
        }
        #endregion

    }

}
