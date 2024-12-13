using CommunityToolkit.Mvvm.Input;
using ProjectManagementApp.Helper;
using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectManagementApp.ViewModels.Abstract
{
    public abstract class InfoViewModel<T> : WorkspaceViewModel
    {
        #region DB
        protected readonly ZarzadanieProjektami2Entities zarzadanieProjektami2Entities;
        #endregion

        #region LoadCommand
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => LoadAllForOne(0)); 
                return _LoadCommand;
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
                    LoadAllForOne(0); 
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
        public InfoViewModel(String displayName)
        {
            zarzadanieProjektami2Entities = new ZarzadanieProjektami2Entities();
            base.DisplayName = displayName;
        }
        #endregion

        #region Helpers
        
        public abstract void LoadAllForOne(int id);
        #endregion
    }
}
