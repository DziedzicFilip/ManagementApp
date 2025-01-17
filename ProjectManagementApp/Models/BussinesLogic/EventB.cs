using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectManagementApp.Models.BussinesLogic
{
    public class EventB : DateBaseClass
    {
        public EventB(ZarzadanieProjektami2Entities db) : base(db)
        {

        }

        public IQueryable<KeyAndValue> GetEventKeyAndValue()
        {
            var events =
                (
                from Wydarzenia in db.Wydarzenia
                select new KeyAndValue
                {
                    Key = Wydarzenia.wydarzenie_id,
                    Value = Wydarzenia.nazwa,
                }
                ).ToList().AsQueryable();
          // MessageBox.Show(events.ToString());
            return events;
        }
    }


}
