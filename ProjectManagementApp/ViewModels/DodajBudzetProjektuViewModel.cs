using ProjectManagementApp.Models.BussinesLogic;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
using System.Linq;

namespace ProjectManagementApp.ViewModels
{
    public class DodajBudzetProjektuViewModel : JedenViewModel<BudzetProjektu>
    {
        #region Konstruktor
        public DodajBudzetProjektuViewModel() : base("Dodaj Budzet Projektu")
        {
            item = new BudzetProjektu();
        }
        #endregion

        #region Pola

        public decimal? CalkowityBudzet
        {
            get
            {
                return item.calkowity_budzet;
            }
            set
            {
                item.calkowity_budzet = value;
                OnPropertyChanged(() => CalkowityBudzet);
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
            var existingBudget = (from b in zarzadanieProjektami2Entities.BudzetProjektu
                                   where b.projekt_id == item.projekt_id
                                   select b).FirstOrDefault();



            if (existingBudget != null)
            {
                // Aktualizuj istniejący budżet
                existingBudget.calkowity_budzet = item.calkowity_budzet;
                existingBudget.wydana_kwota = item.wydana_kwota;
                existingBudget.pozostala_kwota = item.pozostala_kwota;
            }
            else
            {
                // Dodaj nowy budżet
                zarzadanieProjektami2Entities.BudzetProjektu.Add(item);
            }

            zarzadanieProjektami2Entities.SaveChanges();
        }

        #endregion
    }
}
