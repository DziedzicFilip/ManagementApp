using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ProjectManagementApp.ViewModels
{
    public class WszystkieTagiViewModel : WszystkieViewModel<Tagi>
    {
        public WszystkieTagiViewModel() :base("Wszystie Tagi")
        {

        }
        public override void Load()
        {
            List = new ObservableCollection<Tagi>
                (
                   zarzadanieProjektami2Entities.Tagi.ToList()
                );
        }
        public override void OpenNewProject()
        {

            var newProjectWindow = new NowyTagWindowView();
            newProjectWindow.Show();
        }

    }
   
}
