using GalaSoft.MvvmLight.Messaging;
using ProjectManagementApp.Helper;
using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ProjectManagementApp.ViewModels
{


  
    public abstract class JedenViewModel  <T> : WorkspaceViewModel
    {

        #region DB
        protected ZarzadanieProjektami2Entities zarzadanieProjektami2Entities;
        #endregion
        #region Item
        protected T item;
        #endregion
        #region Command
        private BaseCommand _Add;
        public ICommand Add
        {
            get
            {
                if (_Add == null)
                    _Add = new BaseCommand(() => ADD());
                return _Add;
            }

        }
        private ICommand _Cancel;
        public ICommand Cancel
        {
            get
            {
                if (_Cancel == null)
                    _Cancel = new BaseCommand(() => Close());
                return _Cancel;
            }
        }

        private BaseCommand _ShowAllProjkety;
        public ICommand ShowProjekty
        {
            get
            {
                if (_ShowAllProjkety == null)
                {
                    _ShowAllProjkety = new BaseCommand(() => showAllProjekty());

                }
                return _ShowAllProjkety;
            }
        }

        #endregion


        #region Constructor
        public JedenViewModel(string displayname)
        {

            base.DisplayName = displayname;
            zarzadanieProjektami2Entities = new ZarzadanieProjektami2Entities();
            

        }
        #endregion


        public abstract void ADD();
        #region Helpers
        public void Close()
        {
            OnRequestClose();
        }

        public void showAllProjekty()
        {
           
            Messenger.Default.Send<string>("ProjektyALL");
        }

        #endregion
        #region Validation
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion
    }
}
