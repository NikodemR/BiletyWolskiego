using System;
using System.Collections.Generic;
using Bilety;

namespace BiletyWeb
{
    public partial class Bilety : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlUczelnia.DataTextField = "Display";
                ddlUczelnia.DataValueField = "Value";
                List<object> lista = new List<object>();
                foreach (var value in Enum.GetValues(typeof(KartaMiejska.RodzajUczelni)))
                {
                    lista.Add(new { Value = (int)value, Display = value.ToString() });
                }
                ddlUczelnia.DataSource = lista;
                ddlUczelnia.DataBind(); 
            }
           
        }

        protected void btnSprawdzWszystkie_Click(object sender, EventArgs e)
        {
            DataAccessLayer.SendMailOrUpdateRecord(DataAccessLayer.GetFilteredCards(DataAccessLayer.GetAllCards()));
        }

        protected void btnSprawdz_Click(object sender, EventArgs e)
        {
            try
            {
                Wiadomosc.WyslijWiadomosc(GetValues());
            }
            catch(Exception exception)
            {
                //Response.Write("<script>alert('Nie odnaleziono karty w systemie MPK. Prosimy o sprawdzenie poprawności wprowadzonych danych.')</script>");
                Response.Write("<script>alert('" + exception.Message + "')</script>");
            }
        }

        protected void btnDodaj0_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessLayer.Insert(GetValues());
            }
            catch(Exception exception)
            {
                //Response.Write("<script>alert('Nie odnaleziono karty w systemie MPK. Prosimy o sprawdzenie poprawności wprowadzonych danych.')</script>");
                Response.Write("<script>alert('"+exception.Message+"')</script>");
            }
        }

        private KartaMiejska GetValues()
        {
            KartaMiejska karta = new KartaMiejska();
            karta.NrAlbumu = tbNumerAlbumu.Text;
            karta.TypUczelni = ddlUczelnia.SelectedValue;
            karta.AdresMail = tbEmail.Text;
            karta.DataWaznosci = PobierzDane.SprawdzDateWaznosci(karta);
            karta.IleDniZostalo = PobierzDane.ObliczIleDniZostalo(karta);
            return karta;
        }
    }

    
}