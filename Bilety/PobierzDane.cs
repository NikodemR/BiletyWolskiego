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
            string adresUrl = StworzLink(karta);
            string html = WczytajKodStrony(adresUrl);
            return PobierzDateZeStrony(html);
        }

        private static string StworzLink(KartaMiejska karta)
        {
            return "http://www.kkm.krakow.pl/pl/sprawdz-waznosc-biletow-zapisanych-na-karcie/index,1.html?cityCardType=" +
                karta.TypUczelni + "&dateValidity =" + DateTime.Today.ToString("dd-MM-yyyy") + "&identityNumber=" +
                karta.NrAlbumu + "&sprawdz_kkm=Sprawdź";
            //Wolski królem Polski
        }
        private static string WczytajKodStrony(string link)
        {
            return new System.Net.WebClient().DownloadString(link);
        }
        private static string PobierzDateZeStrony(string html)
        {
            return html.Substring(html.IndexOf("Data ko") + 27, 10);
        }

    }
}
