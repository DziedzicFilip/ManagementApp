using iTextSharp.text.pdf;
using ProjectManagementApp.Models.BussinesLogic;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModels
{
    public class DodajZadaniaProjektuViewModel : JedenViewModel<Zadania>
    {
        public DodajZadaniaProjektuViewModel() : base("Dodaj Zadania")
        {

            item = new Zadania();
        }

        #region  Pola

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

        public string Opis
        {
            get
            {
                return item.opis;
            }
            set
            {
                item.opis = value;
                OnPropertyChanged(() => Opis);
            }
        }

        public string Status
        {
            get
            {
                return item.status;
            }
            set
            {
                item.status = value;
                OnPropertyChanged(() => Status);
            }
        }
       
        public int? IdProjektu
        {
            get
            {
                return item.projekt_id;
            }
            set
            {
                item.projekt_id = value;
                OnPropertyChanged(() => IdProjektu);
            }
        }
        #endregion
        #region Propertis Dla ComboBox

        public IQueryable<KeyAndValue> ProjketyItems
        {
            get
            {
                return new ProjektB(zarzadanieProjektami2Entities).GetProjektyKeyAndValue();
            }
        }
        #endregion

        #region Helpers

        public override void ADD()
        {
           
            switch (item.status)
            {
                case string s when s.Contains("Nie Rozpoczęte"):
                    item.status= "Nie Rozpoczęte";
                    break;
                case string s when s.Contains("W Trakcie"):
                    item.status = "Nie Rozpoczęte";
                    break;
                case string s when s.Contains("Zakończone"):
                    item.status = "Nie Rozpoczęte";
                    break;
            }
            
            zarzadanieProjektami2Entities.Zadania.Add(item);
            zarzadanieProjektami2Entities.SaveChanges();
        }
        #endregion
    }
    }
