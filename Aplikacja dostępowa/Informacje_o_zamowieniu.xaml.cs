using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Restauracja_Bazy_Danych.Helper;
using MySql.Data.MySqlClient;

namespace Restauracja_Bazy_Danych
{
    /// <summary>
    /// Logika interakcji dla klasy Informacje_o_zamowieniu.xaml
    /// </summary>
    public partial class Informacje_o_zamowieniu : Window
    {
        public int Id_zamowienia { get; set; }

        public Informacje_o_zamowieniu(int Id)
        {
            InitializeComponent();
            load_informations(Id);
            Id_zamowienia = Id;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void load_informations(int Id_zam)
        {
            MySqlConnection conn;
            string myConnectionString = "server=localhost;uid=root;" +
                "pwd=Starwars2;database=restauracja";

            conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();

            MySqlCommand command;
            string query = "CALL potrawy_z_zamowienia(" + Id_zam + ")";
            command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();
            int i = 0;
            List<informacja_cena_nazwa> lista_potraw = new List<informacja_cena_nazwa>();

            //informacje_txt.Text += "|    nazwa    |    cena    |\n";
            while (reader.Read())
            {
                lista_potraw.Add(new informacja_cena_nazwa() { nazwa = reader.GetValue(0).ToString(), cena = reader.GetValue(1).ToString() + " zł" });
                string tmp = "   " + (i + 1) as string + ". " + lista_potraw[i].nazwa + "   \t" + lista_potraw[i].cena + "\n";
                Console.WriteLine(tmp);
                informacje_txt.Text += tmp;
                i++;
            }
            reader.Close();
        }

        public class informacja_cena_nazwa
        {
            public string cena { get; set; }
            public string nazwa { get; set; }
        }
    }
}
