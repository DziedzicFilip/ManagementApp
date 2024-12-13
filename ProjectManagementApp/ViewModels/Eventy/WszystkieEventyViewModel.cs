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
        public override void OpenNewProject()
        {

            var newEventWindow = new NowyEventWindow();
            newEventWindow.Show();
        }
        public override void OpenInfoView()
        {
            throw new NotImplementedException();    
        }
        #endregion
    }
    }
