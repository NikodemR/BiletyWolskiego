using System;
using System.Net;

namespace Bilety
{
    public class PobierzDane
    {
        public static Func<KartaMiejska, string> SprawdzDateWaznosciKarty = k => PobierzDaneZeStrony(WczytajKodHtmlStrony(UtworzLink(k)));

        private static readonly Func<KartaMiejska, string> UtworzLink = k => "http://www.kkm.krakow.pl/pl/sprawdz-waznosc-biletow-zapisanych-na-karcie/index,1.html?cityCardType=" +
                k.TypUczelni + "&dateValidity =" + DateTime.Today.ToString("dd-MM-yyyy") + "&identityNumber=" +
                k.NrAlbumu + "&sprawdz_kkm=Sprawdź";

        private static readonly Func<string, string> WczytajKodHtmlStrony = s => new WebClient().DownloadString(s);

        private static readonly Func<string, string> PobierzDaneZeStrony = s => s.Substring(s.IndexOf("Data ko") + 27, 10);

    }
}
