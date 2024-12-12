using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
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
    public class RyzykaProjektuViewModel : WszystkieViewModel<RyzykaProjketuForAllView>
    {
        public RyzykaProjektuViewModel()
        : base("Ryzyka")
        {

        }
        public override void Load()
        {
            List = new ObservableCollection<RyzykaProjketuForAllView>
            (
                from RyzykaProjektu in zarzadanieProjektami2Entities.RyzykaProjektu
                select new RyzykaProjketuForAllView
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

            var newProjectWindow = new NowyProjektWindow();
            newProjectWindow.Show();
        }




    }
}

