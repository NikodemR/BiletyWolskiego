using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilety
{
    class PobierzDane
    {

        public static string ZrobLink(KartaMiejska karta)
        {
            string link = "http://www.kkm.krakow.pl/pl/sprawdz-waznosc-biletow-zapisanych-na-karcie/index,1.html?cityCardType=" + karta.TypUczelni + "&dateValidity =" + DateTime.Today.ToString("dd-MM-yyyy") + "&identityNumber=" + karta.NrAlbumu + "&sprawdz_kkm=Sprawdź";
            var html = new System.Net.WebClient().DownloadString(link);
            string dataWaznosci = html.Substring(html.IndexOf("Data ko") +27, 10);
            return dataWaznosci;

        }
        
        /*public static string SprawdzDateWaznosciKarty()
        {
            
            var html = new System.Net.WebClient().DownloadString();
            string dataWaznosci = html.Substring(html.IndexOf("2016-07-23"), 10);
            return dataWaznosci;
        }*/
    }
}
