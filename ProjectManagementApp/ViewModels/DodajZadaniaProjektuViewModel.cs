using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModels
{
    public class DodajZadaniaProjektuViewModel : JedenViewModel<Zadania>
    {
        public DodajZadaniaProjektuViewModel ():base("Dodaj Zadania") {

            item = new Zadania();
        }

        #region  Pola

        #endregion

    }
}
