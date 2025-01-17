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
    public class DodajNotatakiProjektViewModel : JedenViewModel<NotatkiProjekty> 
    {
        public DodajNotatakiProjektViewModel() : base("Dodaj Notatki Projektu")
        {
            item = new NotatkiProjekty();
        }




        #region Pola

        public string tresc_notatki
        {
            get
            {
                return item.tresc_notatki;
            }
            set
            {
                item.tresc_notatki = value;
                OnPropertyChanged(() => tresc_notatki);
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
        public DateTime DataDodania
        {
            get
            {
                return item.data_utworzenia.Value;
            }
            set
            {
                item.data_utworzenia = value;
                OnPropertyChanged(() =>DataDodania);

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
            DataDodania = DateTime.Now;
            zarzadanieProjektami2Entities.NotatkiProjekty.Add(item);
            zarzadanieProjektami2Entities.SaveChanges();
        }
        #endregion


    }





}
