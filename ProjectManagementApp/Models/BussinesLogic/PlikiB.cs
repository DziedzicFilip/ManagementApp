using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectManagementApp.Models.BussinesLogic
{
    public class PlikiB : DateBaseClass
    {

        public PlikiB(ZarzadanieProjektami2Entities db) : base(db)
        {

        }

        public string WybierzPlik(string SciezkaPliku)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                return SciezkaPliku = openFileDialog.FileName;


            }
            return null;
        }
    }
}
