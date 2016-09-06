using System.Net.Mail;

namespace Bilety
{
    public static class Wiadomosc
    {
        public static string AdresMail { get; set; }

        public static string TrescWiadomosci(string dataWaznosci, int ileDniZostalo)
        {
            return "Data ważności karty miejskiej kończy się: " + dataWaznosci + ". Do zakończenia ważności karty miejskiej pozostalo " + ileDniZostalo.ToString() + " dni.";
        }

        public static void WyslijWiadomosc(KartaMiejska karta)
        {
            karta.DataWaznosci = PobierzDane.SprawdzDateWaznosci(karta);
            karta.IleDniZostalo = PobierzDane.ObliczIleDniZostalo(karta);
            MailMessage mail = new MailMessage("waznosc.kkm@gmail.com", karta.AdresMail, "Przypomnienie o końcu ważności Karty Komunikacji Miejskiej.",
                 TrescWiadomosci(karta.DataWaznosci, karta.IleDniZostalo));
            
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("waznosc.kkm@gmail.com", "kanarylubiadolary");
            client.EnableSsl = true;
            client.Send(mail);

        }
    }
}
