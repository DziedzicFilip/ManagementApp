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
    public  class PodsumowanieWindowViewModel : WszystkieViewModel<InfoProjekt>
    {
        public int ProjektID { get; set; }
        public PodsumowanieWindowViewModel(int projektID) :base(" ") { ProjektID = projektID; }
        public override void Load()
        {

            List = new ObservableCollection<InfoProjekt>
            (
                from PodsumowanieCzasu in zarzadanieProjektami2Entities.PodsumowanieCzasu
                where PodsumowanieCzasu.projekt_id == ProjektID
                select new InfoProjekt
                {
                    CalkowityCzas = (double)(PodsumowanieCzasu.calkowity_czas),
                    DataRozpoczenciaPodsumowanie = PodsumowanieCzasu.data_rozpoczecia ?? DateTime.Now,
                    DataZakonczeniaPodsumowanie = PodsumowanieCzasu.data_zakonczenia ?? DateTime.Now


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
