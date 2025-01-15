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
    internal class RyzkoProjetuWindowViewModel : WszystkieViewModel<InfoProjekt>
    {
        public int ProjektID { get; set; }

        public RyzkoProjetuWindowViewModel():base("Ryzko") {

         
        }
        public override void Load()
        {
            List = new ObservableCollection<InfoProjekt>
            (
                from RyzykaProjektu in zarzadanieProjektami2Entities.RyzykaProjektu
              
                select new InfoProjekt
                {
                    
                    SrodkiZapobiegawcze = RyzykaProjektu.srodki_zapobiegawcze,
                    Prawdopodobienstwo = RyzykaProjektu.prawdopodobienstwo,
                    Wplyw = RyzykaProjektu.wplyw,
                    Opis = RyzykaProjektu.opis,
                    NazwaProjektu = RyzykaProjektu.Projekty.nazwa
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
