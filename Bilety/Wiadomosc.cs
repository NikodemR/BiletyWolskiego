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

        public static string TrescWiadomosci(string DataWaznosci, string IleDniZostalo)
        {
            return "Data ważności karty miejskiej kończy się: " + DataWaznosci + ". Do zakończenia ważności karty miejskiej pozostalo " + IleDniZostalo + " dni.";
        }

    }
}
