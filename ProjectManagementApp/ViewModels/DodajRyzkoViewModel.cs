using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using ProjectManagementApp.Models.EntitiesForView;
using ProjectManagementApp.Models.BussinesLogic;
using System.Reflection;
namespace ProjectManagementApp.ViewModels
{
   public class DodajRyzkoViewModel : JedenViewModel<RyzykaProjektu>
    {
        #region  Konstruktor 
          public DodajRyzkoViewModel() : base("Dodaj Ryzko")
        {
            item = new RyzykaProjektu();
        }

        #endregion

        #region Pola

      

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
        public string wplyw
        {
            get
            {
                return item.wplyw;
            }
            set
            {
                item.wplyw = value;
                OnPropertyChanged(() => wplyw);
                ShowMessageBox(wplyw);
            }
        }

        public string prawdopodobienstwo
        {
            get
            {
                return item.prawdopodobienstwo;
            }
            set
            {
                item.prawdopodobienstwo = value;
                OnPropertyChanged(() => prawdopodobienstwo);
                ShowMessageBox(prawdopodobienstwo);
            }
        }

        public string srodki_zapobiegawcze
        {
            get
            {
                return item.srodki_zapobiegawcze;
            }
            set
            {
                item.srodki_zapobiegawcze = value;
                OnPropertyChanged(() => srodki_zapobiegawcze);
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
           
            switch (item.wplyw)
            {
                case string s when s.Contains("Niski"):
                    item.wplyw = "Niski";
                    break;
                case string s when s.Contains("Średni"):
                    item.wplyw = "Średni";
                    break;
                case string s when s.Contains("Wysoki"):
                    item.wplyw = "Wysoki";
                    break;
            }
            switch (item.prawdopodobienstwo)
            {
                case string s when s.Contains("Niskie"):
                    item.prawdopodobienstwo = "Niski";
                    break;
                case string s when s.Contains("Średnie"):
                    item.prawdopodobienstwo = "Średni";
                    break;
                case string s when s.Contains("Wysokie"):
                    item.prawdopodobienstwo = "Wysokie";
                    break;
            }

            var execRyzko = new ProjektB(zarzadanieProjektami2Entities).existingRyzykaProjektu(item.projekt_id);
            if(execRyzko != null)
            {
               
                execRyzko.opis = item.opis;
                execRyzko.wplyw = item.wplyw;
                execRyzko.prawdopodobienstwo = item.prawdopodobienstwo;
                execRyzko.srodki_zapobiegawcze = item.srodki_zapobiegawcze;
            }
            else
            {
                
                zarzadanieProjektami2Entities.RyzykaProjektu.Add(item);
            }
            zarzadanieProjektami2Entities.SaveChanges();
        }

        #endregion
    }
}
