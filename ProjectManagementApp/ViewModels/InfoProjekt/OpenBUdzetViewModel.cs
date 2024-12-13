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
    public  class OpenBUdzetViewModel : WszystkieViewModel<InfoProjekt>
    {
        public OpenBUdzetViewModel():base(":") { }
        public override void Load()
        {
            List = new ObservableCollection<InfoProjekt>
            (
                from BudzetProjektu in zarzadanieProjektami2Entities.BudzetProjektu
                where BudzetProjektu.projekt_id == 1093
                select new InfoProjekt
                {
                    CalkowityBudzet =(double)( BudzetProjektu.calkowity_budzet),
                    WydanaKwota = (double)(BudzetProjektu.wydana_kwota),
                    PozostalaKwota = (double)(BudzetProjektu.pozostala_kwota),


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
