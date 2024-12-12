using ProjectManagementApp.Helper;
using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjectManagementApp.ViewModels
{
    public class NowyProjektViewModel : JedenViewModel<Projekty>
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


        #region Helpers
     
        
        public override void ADD()
        {
        
                zarzadanieProjektami2Entities.Projekty.Add(item);
                zarzadanieProjektami2Entities.SaveChanges();
            MessageBox.Show("Projekt został pomyślnie dodany!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

            Close();
        }
        #endregion
    }

}



