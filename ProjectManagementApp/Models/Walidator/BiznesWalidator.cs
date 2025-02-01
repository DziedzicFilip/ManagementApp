using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Models.Walidator
{
    public class BiznesWalidator :
        Walidator
    {
        public static string SprawdzTerminy(DateTime? dataRozpoczecia, DateTime? dataZakonczenia)
        {
            try
            {
                if (dataRozpoczecia.HasValue && dataZakonczenia.HasValue)
                {
                    if (dataRozpoczecia.Value > dataZakonczenia.Value)
                        return "Data rozpoczęcia musi być wcześniejsza niż data zakończenia";
                }
            }
            catch (Exception e)
            {
              
            }
            return null;
        }
        public static string SprawdzLiczbeNieUjemna(decimal liczba)
        {
            if (liczba < 0)
                return "Liczba nie może być ujemna";
            return null;
        }
        public static string SprawdzDatePrzyszlosci(DateTime? data)
        {
            if (!data.HasValue)
                return "Data nie może być pusta";

            if (data.Value < DateTime.Now)
                return "Data musi być w przyszłości";

            return null;
        }


    }
}
