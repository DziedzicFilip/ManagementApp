using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Helper;
using System.Windows.Input;

namespace ProjectManagementApp.ViewModels
{
    public class WszystkieProjektyViewModel : WorkspaceViewModel
    {
        #region DB
        private readonly ZarzadanieProjektami2Entities zarzadanieProjektami2Entities;
        
        
        #endregion
        #region LoadCommand
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if(_LoadCommand == null)
                
                    _LoadCommand = new BaseCommand(() => load());
                return _LoadCommand;   
                
            }
                

        }
        #endregion
        #region List
        private ObservableCollection<Projekty> _List;
        public ObservableCollection<Projekty> List
        {
            get {
                if (_List == null)
                {
                    load();
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
        public WszystkieProjektyViewModel()
        {
            base.DisplayName = "Projkety";
            zarzadanieProjektami2Entities = new ZarzadanieProjektami2Entities();
        }
        #endregion
        #region Helpers
        private void load()
        {
            List = new ObservableCollection<Projekty>
                (
                   zarzadanieProjektami2Entities.Projekty.ToList()
                );
        }
        #endregion

    }
}