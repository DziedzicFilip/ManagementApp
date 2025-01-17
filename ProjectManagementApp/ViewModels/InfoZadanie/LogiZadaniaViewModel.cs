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
    internal class LogiZadaniaViewModel : WszystkieViewModel<ZadanieInfo> 
    {
        public LogiZadaniaViewModel():base("") { }
        public override void Load()
        {
            List = new ObservableCollection<ZadanieInfo>
            (
                from LogiZadan in zarzadanieProjektami2Entities.LogiZadan

                select new ZadanieInfo
                {
                    DzialanieZadanie = LogiZadan.dzialanie,
                    StatusPrzedZadanie = LogiZadan.status_przed,
                    StatusPoZadanie = LogiZadan.status_po,
                    DataZmiany = LogiZadan.data_zmiany ?? DateTime.Now,
                    NazwaZadanie = LogiZadan.Zadania.nazwa
                    
                }

            );
        }
       
    }
}
