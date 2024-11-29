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
    public class WszystkieProjektyViewModel : WszystkieViewModel<Projekty>
    {
       
        #region Constructor
        public WszystkieProjektyViewModel()
            :base("Projkety")
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

    }
}