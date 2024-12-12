using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectManagementApp.ViewModels
{
    public class NowyTagViewModel : JedenViewModel<Tagi>
    {
        public NowyTagViewModel() :base("Nowy Tag")
        {

            item = new Tagi();
        }

        public string Nazwa
        {
            get {
                return item.nazwa;
                }
            set
            {
                item.nazwa = value;
                OnPropertyChanged(() => Nazwa);


            }
        }
        
        public override void ADD()
        {
            zarzadanieProjektami2Entities.Tagi.Add(item);
            zarzadanieProjektami2Entities.SaveChanges();

            MessageBox.Show("TAG został pomyślnie dodany!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
