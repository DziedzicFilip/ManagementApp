using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ProjectManagementApp.ViewModels
{
   public class CzasPracyWindowViewModel : WszystkieViewModel<InfoProjekt>
    {
        public CzasPracyWindowViewModel():base(" ") {
        


        }
         public override void Load()
        {
            List = new ObservableCollection<InfoProjekt>
            (
                from RejestrCzasuPracyProjekt in zarzadanieProjektami2Entities.RejestrCzasuPracyProjekt
                where RejestrCzasuPracyProjekt.projekt_id == 1093
                select new InfoProjekt
                {
                    CzasSpedzony = (double)(RejestrCzasuPracyProjekt.czas_spedzony ?? 0m),
                    DataPomiaruCzasu = RejestrCzasuPracyProjekt.data ?? DateTime.Now,

                }

            );
        }


        public override void OpenNewProject()
        {

            //var newProjectWindow = new NowyProjektWindow();
            //newProjectWindow.Show();
        }
        public override void OpenInfoView()
        {
                ///
        }
    }
}
