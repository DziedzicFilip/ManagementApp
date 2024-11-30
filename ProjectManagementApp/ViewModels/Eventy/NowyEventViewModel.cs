using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModels
{
    public class NowyEventViewModel : JedenViewModel<Wydarzenia>
    {





        public NowyEventViewModel():base("Nowe Wydarzenie") {

           item = new Wydarzenia();
            OnPropertyChanged(() => Data_rozpoczecia);
            OnPropertyChanged(() => Data_zakonczenia);
        }

        #region Propertis
        public string Nazwa
        {
            get
            {
                return item.nazwa;
            }
            set
            {
                item.nazwa = value;
                OnPropertyChanged(() => Nazwa);


            }


        }

        public string opis
        {
            get
            {
                return item?.opis;

            }
            set
            {
                item.opis = value;
                OnPropertyChanged(() => opis);
            }
        }


        public DateTime? Data_rozpoczecia
        {
            get => item?.data_rozpoczecia ?? DateTime.Now;
            set
            {
                item.data_rozpoczecia = value;
                OnPropertyChanged(() => Data_rozpoczecia);


            }
        }
        public DateTime? Data_zakonczenia
        {
            get => item?.data_zakonczenia ?? DateTime.Now;
            set
            {
                item.data_zakonczenia = value;
                OnPropertyChanged(() => Data_zakonczenia);


            }
        }



        #endregion

        #region Helpers
        public override void ADD()
        {

            zarzadanieProjektami2Entities.Wydarzenia.Add(item);
            zarzadanieProjektami2Entities.SaveChanges();


            Close();
        }
        #endregion
    }
}
