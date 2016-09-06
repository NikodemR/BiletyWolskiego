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
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;

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

        public KartaMiejska GetValues()
        {
            KartaMiejska karta = new KartaMiejska();
            karta.NrAlbumu = textBox1.Text;
            karta.TypUczelni = comboBox1.SelectedValue.ToString();
            karta.AdresMail = textBoxMail.Text;
            karta.DataWaznosci = PobierzDane.SprawdzDateWaznosci(karta);
            karta.IleDniZostalo = PobierzDane.ObliczIleDniZostalo(karta);
            return karta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Wiadomosc.WyslijWiadomosc(GetValues());
            }
            catch
            {
                MessageBox.Show("Nie odnaleziono karty w systemie MPK. Prosimy o sprawdzenie poprawności wprowadzonych danych.");
            }
        }

        private void dodajButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessLayer.Insert(GetValues());
            }
            catch
            {
                MessageBox.Show("Nie odnaleziono karty w systemie MPK. Prosimy o sprawdzenie poprawności wprowadzonych danych.");
            }
        }

        private void checkAllButton_Click(object sender, EventArgs e)
        {
            DataAccessLayer.SendMailOrUpdateRecord(DataAccessLayer.GetFilteredCards(DataAccessLayer.GetAllCards()));
        }
    }
}
