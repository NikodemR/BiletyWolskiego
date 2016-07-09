using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.Net.Mail;

namespace Bilety
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Text";
            List<object> lista = new List<object>();
            foreach (var value in Enum.GetValues(typeof(KartaMiejska.RodzajUczelni)))
            {
                lista.Add(new { Value = (int)value, Text = value.ToString() });
            }
            comboBox1.DataSource = lista;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KartaMiejska karta = new KartaMiejska();
            karta.NrAlbumu = textBox1.Text;
            karta.TypUczelni = comboBox1.SelectedValue.ToString();
            textBox2.Text = PobierzDane.SprawdzDateWaznosci(karta);
            textBox3.Text = PobierzDane.ObliczIleDniZostalo(karta);
            karta.DataWaznosci = textBox2.Text;
            karta.IleDniZostalo = textBox3.Text;

            Wiadomosc.AdresMail = textBoxMail.Text;
            MailMessage mail = new MailMessage("waznosc.kkm@gmail.com", Wiadomosc.AdresMail, "Przypomnienie o końcu ważności Karty Komunikacji Miejskiej.",
                Wiadomosc.TrescWiadomosci(karta.DataWaznosci, karta.IleDniZostalo));

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("waznosc.kkm@gmail.com", "kanarylubiadolary");
            client.EnableSsl = true;

            if (Int32.Parse(karta.IleDniZostalo) <= 30)
            {
                client.Send(mail);
            }
        }
    }
}
