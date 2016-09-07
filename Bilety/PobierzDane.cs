using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Bilety
{
    class PobierzDane
    {

        public static string SprawdzDateWaznosci(KartaMiejska karta)
        {
            return PobierzDateZeStrony(WczytajKodStrony(StworzLink(karta)));
        }

        public static string ObliczIleDniZostalo (KartaMiejska karta)
        {
            DateTime aktualnaData = DateTime.Today;
            DateTime dataWaznosci = DateTime.Parse(PobierzDateZeStrony(WczytajKodStrony(StworzLink(karta))));
            return (dataWaznosci - aktualnaData).TotalDays.ToString();
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
