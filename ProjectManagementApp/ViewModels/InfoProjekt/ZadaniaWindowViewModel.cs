using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModels
{
    public  class ZadaniaWindowViewModel :  WszystkieViewModel<InfoProjekt>
    {
        public ZadaniaWindowViewModel():base("") { }
        public override void Load()
        {
            List = new ObservableCollection<InfoProjekt>
            (
                from Zadania in zarzadanieProjektami2Entities.Zadania
                where Zadania.projekt_id == 1093
                select new InfoProjekt
                {
                    NazwaZadania = Zadania.nazwa,
                    OpisZadania = Zadania.opis,
                    StatusZadania = Zadania.status,
                    DataRozpoczeciaZadnia = Zadania.data_rozpoczecia ?? DateTime.Now,
                    DataZakaonczeniaZadania = Zadania.data_zakonczenia ?? DateTime.Now,

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
