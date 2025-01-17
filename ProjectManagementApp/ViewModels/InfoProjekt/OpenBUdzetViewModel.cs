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
        public int ProjektID { get; set; }
        public OpenBUdzetViewModel() :base(":") { }
        public override void Load()
        {
            List = new ObservableCollection<InfoProjekt>
            (
                from BudzetProjektu in zarzadanieProjektami2Entities.BudzetProjektu
              
                select new InfoProjekt
                {
                    NazwaProjektu = BudzetProjektu.Projekty.nazwa,
                    CalkowityBudzet = (double?)(BudzetProjektu.calkowity_budzet) ?? 0,
                    WydanaKwota = (double?)(BudzetProjektu.wydana_kwota) ?? 0,
                    PozostalaKwota = (double?)(BudzetProjektu.pozostala_kwota) ?? 0,
                }

            );
        }


       
    }
}
