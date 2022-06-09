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
    /// Logika interakcji dla klasy Kierownik_window.xaml
    /// </summary>
    public partial class Kierownik_window : Window
    {
        public Kierownik_window()
        {
            InitializeComponent();
            loadStackPanelData();
        }

        private void dodaj_potrawe_Click(object sender, RoutedEventArgs e)
        {

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
            string[] Output = new string[6];

            sql = "SELECT * FROM skladnik";
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            List<Skladnik_Lista> SkladnikList = new List<Skladnik_Lista>();

            while (reader.Read())
            {
                Output[0] = reader.GetValue(0) + "";                             // Id_Skladnik
                Output[1] = reader.GetValue(1).ToString().ToUpper() + "";        // Nazwa
                Output[2] = reader.GetValue(2) + "";                             // Ilosc
                Output[3] = reader.GetValue(3) + "";                             // Id_jednostka
                Output[4] = reader.GetValue(4) + "";                             // Cena_Za_Jednostke
                Output[5] = reader.GetValue(5) + "";                             // Czy_Widoczn_W_Menu
                SkladnikList.Add(new Skladnik_Lista() { Id_Skladnik = Output[0], Nazwa = Output[1], Ilosc = Output[2], Id_Jednostka = Output[3], 
                                                        Cena_Za_Jednostke = Output[4], Czy_Widoczn_W_Menu = Output[5] });
            }
            reader.Close();

            UserList.ItemsSource = SkladnikList;
        }

        public class Skladnik_Lista
        {
            public string Id_Skladnik { get; set; }
            public string Nazwa { get; set; }
            public string Ilosc { get; set; }
            public string Id_Jednostka { get; set; }
            public string Cena_Za_Jednostke { get; set; }
            public string Czy_Widoczn_W_Menu { get; set; }
            public int enumNumber { get; set; }
        }
    }
}
