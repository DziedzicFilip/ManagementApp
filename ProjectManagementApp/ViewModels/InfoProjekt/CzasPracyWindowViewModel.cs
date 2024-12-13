using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProjectManagementApp.Models.Entities;

namespace ProjectManagementApp.ViewModels
{
   public class CzasPracyWindowViewModel : WszystkieViewModel<InfoProjekt>
    {
        public int ProjektID { get; set; }
        public CzasPracyWindowViewModel(int projektID) :base(" ") {
            ProjektID = projektID;


        }
         public override void Load()
        {
            List = new ObservableCollection<InfoProjekt>
            (
                from RejestrCzasuPracyProjekt in zarzadanieProjektami2Entities.RejestrCzasuPracyProjekt
                where RejestrCzasuPracyProjekt.projekt_id == ProjektID
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
