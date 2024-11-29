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
        #region LoadCommand
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
        #endregion
        #region List
        private ObservableCollection<Projekty> _List;
        public ObservableCollection<Projekty> List
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
        #endregion
    }

}
