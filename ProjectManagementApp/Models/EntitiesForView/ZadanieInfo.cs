using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Models.EntitiesForView
{
    public  class ZadanieInfo
    {
        public string NazwaZadanie {  get; set; }
        public string DzialanieZadanie {  set; get; }
        public string StatusPrzedZadanie { set; get; }
        public string StatusPoZadanie { set; get; }
        public DateTime DataZmiany { set; get; }
    }
}
