using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public int? Godzina_rozpoczeciaStart
        {
            get => item?.data_rozpoczecia?.Hour;
            set
            {
                if (value.HasValue && item.data_rozpoczecia.HasValue)
                {
                   
                    item.data_rozpoczecia = item.data_rozpoczecia.Value.AddHours(value.Value - item.data_rozpoczecia.Value.Hour);
                    OnPropertyChanged(() => Godzina_rozpoczeciaStart);
                    OnPropertyChanged(() => Data_rozpoczecia);
                }
            }
        }

        public int? Minuta_rozpoczeciaStart
        {
            get => item?.data_rozpoczecia?.Minute;
            set
            {
                if (value.HasValue && item.data_rozpoczecia.HasValue)
                {
                    
                    item.data_rozpoczecia = item.data_rozpoczecia.Value.AddMinutes(value.Value - item.data_rozpoczecia.Value.Minute);
                    OnPropertyChanged(() => Minuta_rozpoczeciaStart);
                    OnPropertyChanged(() => Data_rozpoczecia);
                }
            }
        }

        public int? Godzina_zakonczeniaEnd
        {
            get => item?.data_zakonczenia?.Hour;
            set
            {
                if (value.HasValue && item.data_zakonczenia.HasValue)
                {
                    item.data_zakonczenia = item.data_zakonczenia.Value.AddHours(value.Value - item.data_zakonczenia.Value.Hour);
                    OnPropertyChanged(() => Godzina_zakonczeniaEnd);
                    OnPropertyChanged(() => Data_zakonczenia);
                }
            }
        }

        public int? Minuta_zakonczeniaEnd
        {
            get => item?.data_zakonczenia?.Minute;
            set
            {
                if (value.HasValue && item.data_zakonczenia.HasValue)
                {
                    item.data_zakonczenia = item.data_zakonczenia.Value.AddMinutes(value.Value - item.data_zakonczenia.Value.Minute);
                    OnPropertyChanged(() => Minuta_zakonczeniaEnd);
                    OnPropertyChanged(() => Data_zakonczenia);
                }
            }
        }

        #endregion

        #region Helpers



        public override void ADD()
        {

          

            zarzadanieProjektami2Entities.Wydarzenia.Add(item);
            zarzadanieProjektami2Entities.SaveChanges();
            MessageBox.Show("Event został pomyślnie dodany!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

            Close();
        }
        #endregion
    }
}
