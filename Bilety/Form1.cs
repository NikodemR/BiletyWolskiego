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
            textBox2.Text = PobierzDane.ZrobLink(karta);
        }
    }
}
