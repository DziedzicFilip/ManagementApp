using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Models.BussinesLogic
{
    public class DateBaseClass
    {
        #region Context
         public  ZarzadanieProjektami2Entities db {  get; set; }

        #endregion
        #region DataBaseClass
        public DateBaseClass(ZarzadanieProjektami2Entities db) {
            this.db = db;
        }
        #endregion
    }
}
