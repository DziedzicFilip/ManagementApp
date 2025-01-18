using GalaSoft.MvvmLight.Messaging;
using ProjectManagementApp.Helper;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.Walidator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjectManagementApp.ViewModels
{
    public class NowyProjektViewModel : JedenViewModel<Projekty>,IDataErrorInfo
    {

      
        #region Constructor
        public NowyProjektViewModel():base("Nowy Projekt")
        {

        
            item = new Projekty();
            OnPropertyChanged(() => data_rozpoczecia); 
            OnPropertyChanged(() => termin);
        }
        #endregion
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


        public DateTime? data_rozpoczecia
        {
            get => item?.data_rozpoczecia ?? DateTime.Now;
            set
            {
                item.data_rozpoczecia = value;
                OnPropertyChanged(() => data_rozpoczecia);
                


            }


        }
        public string status
        {
            get
            {
                return item.status;
            }
            set
            {
                item.status = value;
                OnPropertyChanged(() => status);

            }


        }

        public string priorytet
        {
            get
            {
                return item.priorytet;
            }
            set
            {
                item.priorytet = value;
                OnPropertyChanged(() => priorytet);
            }
            
        }

        public DateTime? termin
        {
            get => item?.termin ?? DateTime.Now;
            set
            {
                item.termin = value;
                OnPropertyChanged(() => termin);

            }
        }



        #endregion
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Nazwa")
                {
                    var komunikat1 = StringWalidator.SprawdzCzyZaczynaSieOdDuzejLitery(this.Nazwa);
                    var komunikat2 = StringWalidator.SprawdzUnikalnoscNazwyProjektu(this.Nazwa, zarzadanieProjektami2Entities);
                    var komunikat3 = StringWalidator.SprawdzCzyNieJestPusty(this.Nazwa);

                    if (komunikat1 != null)
                        komunikat = komunikat1;
                    if (komunikat2 != null)
                        komunikat = komunikat != null ? $"{komunikat}\n{komunikat2}" : komunikat2;
                    if (komunikat3 != null)
                        komunikat = komunikat != null ? $"{komunikat}\n{komunikat3}" : komunikat3;
                }

                if (name == "opis")
                {
                    var komunikatOpis = StringWalidator.SprawdzOpis(this.opis);
                    if (komunikatOpis != null)
                        komunikat = komunikat != null ? $"{komunikat}\n{komunikatOpis}" : komunikatOpis;
                }

                if (name == "data_rozpoczecia")
                {
                    var komunikatData = BiznesWalidator.SprawdzDatePrzyszlosci(this.data_rozpoczecia);
                 

                    if (komunikatData != null)
                        komunikat = komunikat != null ? $"{komunikat}\n{komunikatData}" : komunikatData;
                  
                }

                if(name == "termin")
                {
                    var komunikatData = BiznesWalidator.SprawdzDatePrzyszlosci(this.termin);
                    var komunikatData2 =   BiznesWalidator.SprawdzTerminy(this.data_rozpoczecia, this.termin);

                    if (komunikatData != null)
                        komunikat = komunikat != null ? $"{komunikat}\n{komunikatData2}" : komunikatData2;
                    if (komunikatData2 != null)
                        komunikat = komunikat != null ? $"{komunikat}\n{komunikatData2}" : komunikatData2;
                }



                return komunikat;
            }
        }

        public override bool IsValid()
        {
            if (this["Nazwa"] == null)
                return true;
            return false;
        }
        #endregion

            #region Helpers


        public override void ADD()
        {
            if (IsValid())
                {
                zarzadanieProjektami2Entities.Projekty.Add(item);
                zarzadanieProjektami2Entities.SaveChanges();
                MessageBox.Show("Projekt został pomyślnie dodany!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                Close();
            }
            else
            {
                MessageBox.Show("Niepoprawne dane", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       
        #endregion
    }

}



