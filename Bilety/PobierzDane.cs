using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilety
{
    class PobierzDane
    {

        public static string SprawdzDateWaznosci(KartaMiejska karta)
        {
            string link = StworzLink(karta);
            var html = new System.Net.WebClient().DownloadString(link);
            string dataWaznosci = html.Substring(html.IndexOf("Data ko") +27, 10);
            return dataWaznosci;

        }

        private static string StworzLink(KartaMiejska karta)
        {
            return "http://www.kkm.krakow.pl/pl/sprawdz-waznosc-biletow-zapisanych-na-karcie/index,1.html?cityCardType=" +
                karta.TypUczelni + "&dateValidity =" + DateTime.Today.ToString("dd-MM-yyyy") + "&identityNumber=" +
                karta.NrAlbumu + "&sprawdz_kkm=Sprawdź";
        }
       
    }
}
