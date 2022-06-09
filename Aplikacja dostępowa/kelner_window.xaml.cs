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
    /// Logika interakcji dla klasy kelner_window.xaml
    /// </summary>
    public partial class kelner_window : Window
    {
        public kelner_window()
        {
            InitializeComponent();
            loadStackPanelData();
            DBHelper.EstablishConnection();
        }

        private void dodaj_zamowienie_Click(object sender, RoutedEventArgs e)
        {
            Dodaj_zamowienie testwindow = new Dodaj_zamowienie();
            testwindow.ShowDialog();
            loadStackPanelData();
        }

        private void ukoncz_zamowienie(object sender, RoutedEventArgs e)
        {
            Button clickbtn = sender as Button;

            string index = clickbtn.ToString();
            index = index.Remove(0, 31);

            int intIndex;
            intIndex = Int32.Parse(index);

            MySqlConnection conn;
            string myConnectionString = "server=localhost;uid=root;" +
                "pwd=Starwars2;database=restauracja";

            conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();

            MySqlCommand command;
            string query = "CALL ukoncz_zamowienie(" + intIndex + ")";
            command = new MySqlCommand(query, conn);
            _ = command.ExecuteReader();

            loadStackPanelData();
        }

        private void usun_zamowienie(object sender, RoutedEventArgs e)
        {
            Button clickbtn = sender as Button;

            string index = clickbtn.ToString();
            index = index.Remove(0, 31);

            int intIndex;
            intIndex = Int32.Parse(index);

            MySqlConnection conn;
            string myConnectionString = "server=localhost;uid=root;" +
                "pwd=Starwars2;database=restauracja";

            conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();

            MySqlCommand command;
            string query = "DELETE FROM tab_posr_zamowienie_potrawa WHERE Id_Zamowienie = " + intIndex + ";\n CALL usun_zamowienie(" + intIndex + ");";
            command = new MySqlCommand(query, conn);
            _ = command.ExecuteReader();

            loadStackPanelData();
        }

        private void wyswietl_informacje(object sender, RoutedEventArgs e)
        {
            Button clickbtn = sender as Button;

            string index = clickbtn.ToString();
            index = index.Remove(0, 31);

            int intIndex;
            intIndex = Int32.Parse(index); //indeks zamowienia ktorego informacje chcemy wyswietlic

            Informacje_o_zamowieniu informacje_O_Zamowieniu = new Informacje_o_zamowieniu(intIndex);
            informacje_O_Zamowieniu.ShowDialog();
        }

        private void loadStackPanelData()
        {
            MySqlConnection conn;
            string myConnectionString = "server=localhost;uid=root;" +
                "pwd=Starwars2;database=restauracja";

            conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();

            MySqlCommand command;
            MySqlDataReader reader;
            string sql;
            string[] Output = new string[4];

            sql = "SELECT * FROM zamowienie WHERE Gotowe = 0 AND Id_Zamowienia >0 AND Numer_Stolu >0"; // zamówienia w lokalu (numer stolu > 0), i tylko te niegotowe
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            List<Zamowienie_Lista> ZamowienieList = new List<Zamowienie_Lista>();

            while (reader.Read())
            {
                Output[0] = reader.GetValue(0) + "";
                Output[1] = "Numer Stołu: " + reader.GetValue(1) + "";
                Output[2] = "Data zamowienia: " + reader.GetValue(2).ToString()/*.Remove(10, 9)*/ + ""; // remove usuwa godzine z wyswietlanej zawartosci
                ZamowienieList.Add(new Zamowienie_Lista() { Id_Zamowienia = Output[0], Numer_Stolu = Output[1], Data_Zamowienia = Output[2] });
            }
            reader.Close();

            UserList.ItemsSource = ZamowienieList;
        }

        public class Zamowienie_Lista
        {
            public string Id_Zamowienia { get; set; }
            public string Numer_Stolu { get; set; }
            public string Data_Zamowienia { get; set; }
            public int enumNumber { get; set; }
        }
    }
}
