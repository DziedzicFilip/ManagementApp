using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Models.EntitiesForView
{
    public  class EventInfo
    {
        public string NazwaEventu {  get; set; }
        #region    Pliki
        
        public string NazwaPlikuEvent {  get; set; }
        public string SciezkaPlikuEvent { get; set; }
        public DateTime DataWgraniaPlikuEvent { get; set; }
        #endregion
        #region Notatki
        public string TrescNotatakiEvent { get; set; }
        public DateTime DataUtworzeniaNotatkiEvent { get; set; }

        #endregion

    }
}
