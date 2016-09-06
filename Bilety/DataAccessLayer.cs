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
    class DataAccessLayer
    {
        public static void Insert(KartaMiejska karta)
        {
            string cs = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Jakub\\Documents\\Visual Studio 2015\\Projects\\Bilety\\Bilety\\DaneKlientowKKM.mdf\";Integrated Security=True;Connect Timeout=30";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO DaneUzytkownikow (TypUczelni, NrAlbumu, AdresMail, DataWaznosci) VALUES (@TypUczelni, @NrAlbumu, @AdresMail, @DataWaznosci)";
                    command.Parameters.AddWithValue("@TypUczelni", karta.TypUczelni);
                    command.Parameters.AddWithValue("@NrAlbumu", karta.NrAlbumu);
                    command.Parameters.AddWithValue("@AdresMail", karta.AdresMail);
                    command.Parameters.AddWithValue("@DataWaznosci", karta.DataWaznosci);
                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        // error here
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public static KartaMiejska GetFromDatabase(int Id)
        {
            string cs = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Jakub\\Documents\\Visual Studio 2015\\Projects\\Bilety\\Bilety\\DaneKlientowKKM.mdf\";Integrated Security=True;Connect Timeout=30";
            KartaMiejska karta = new KartaMiejska();

            using (var conn = new SqlConnection(cs))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM DaneUzytkownikow WHERE id = @id";
                cmd.Parameters.AddWithValue("@Id", Id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        karta.AdresMail = reader.GetString(reader.GetOrdinal("AdresMail"));
                    }
                }
            }
            return karta;
        }

        public static List<KartaMiejska> GetAllCards()
        {
            List<KartaMiejska> FullRecordsList = new List<KartaMiejska>();

            string cs = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Jakub\\Documents\\Visual Studio 2015\\Projects\\Bilety\\Bilety\\DaneKlientowKKM.mdf\";Integrated Security=True;Connect Timeout=30";
            using (var conn = new SqlConnection(cs))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM DaneUzytkownikow";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KartaMiejska karta = new KartaMiejska();
                        karta.Id = Convert.ToInt32(reader["Id"]);
                        karta.TypUczelni = reader["TypUczelni"].ToString();
                        karta.NrAlbumu = reader["NrAlbumu"].ToString();
                        karta.AdresMail = reader["AdresMail"].ToString();
                        karta.DataWaznosci = reader["DataWaznosci"].ToString();
                        FullRecordsList.Add(karta);
                    }
                }
            }
            return FullRecordsList;
        }

        public static List<KartaMiejska> GetFilteredCards(List<KartaMiejska> FullRecordsList)
        {
            List<KartaMiejska> FilteredList = FullRecordsList.FindAll(karta => (PobierzDane.ObliczIleDniZostalo(karta) < 16));
            return FilteredList;
        }

        private static void UpdateDataBase(KartaMiejska karta)
        {
            string cs = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Jakub\\Documents\\Visual Studio 2015\\Projects\\Bilety\\Bilety\\DaneKlientowKKM.mdf\";Integrated Security=True;Connect Timeout=30";

            using (var connection = new SqlConnection(cs))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE DaneUzytkownikow SET DataWaznosci = @DataWaznosci Where Id = @Id";
                command.Parameters.AddWithValue("@Id", karta.Id);
                command.Parameters.AddWithValue("@DataWaznosci", PobierzDane.SprawdzDateWaznosci(karta));
                connection.Open();
                int i = command.ExecuteNonQuery();
            }
        }

        public static void SendMailOrUpdateRecord(List<KartaMiejska> GetFilteredCards)
        {
            foreach (KartaMiejska karta in GetFilteredCards)
            {
                if ((PobierzDane.CheckIfEqual(karta))) //&& (PobierzDane.ObliczIleDniZostalo(karta) == 3))
                {
                    Wiadomosc.WyslijWiadomosc(karta);
                }
                else if (!PobierzDane.CheckIfEqual(karta))
                {
                    UpdateDataBase(karta);
                }
            }
        }
    }
}
