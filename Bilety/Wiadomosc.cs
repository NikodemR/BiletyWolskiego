using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;

namespace Bilety
{
    static class Wiadomosc
    {
        public static string AdresMail { get; set; }

        public static string TrescWiadomosci(string DataWaznosci, int IleDniZostalo)
        {
            return "Data ważności karty miejskiej kończy się: " + DataWaznosci + ". Do zakończenia ważności karty miejskiej pozostalo " + IleDniZostalo.ToString() + " dni.";
        }

        public static void WyslijWiadomosc(KartaMiejska karta)
        {
            karta.DataWaznosci = PobierzDane.SprawdzDateWaznosci(karta);
            karta.IleDniZostalo = PobierzDane.ObliczIleDniZostalo(karta);
            MailMessage mail = new MailMessage("waznosc.kkm@gmail.com", karta.AdresMail, "Przypomnienie o końcu ważności Karty Komunikacji Miejskiej.",
                 Wiadomosc.TrescWiadomosci(karta.DataWaznosci, karta.IleDniZostalo));

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("waznosc.kkm@gmail.com", "kanarylubiadolary");
            client.EnableSsl = true;
            client.Send(mail);
        }
    }
}
