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
    /// Logika interakcji dla klasy Dodaj_skladnik.xaml
    /// </summary>
    public partial class Dodaj_skladnik : Window
    {
        public int Id_skladnik { get; set; }

        public Dodaj_skladnik(int Id)
        {
            InitializeComponent();
            load_informations(Id);
            Id_skladnik = Id;
            nowa_ilosc.Text = "0";
            dodaj_ilosc.Text = "0";
        }

        private void TextBox_GotKeyboardFocus1(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if(txtBox == nowa_ilosc)
            {
                txtBox.Text = string.Empty;
                dodaj_ilosc.Text = "0";
            }
        }

        private void TextBox_GotKeyboardFocus2(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox == dodaj_ilosc)
            {
                txtBox.Text = string.Empty;
                nowa_ilosc.Text = "0";
            }
        }

        private void cancelIngr(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void confirmIngr(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn;
                string myConnectionString = "server=localhost;uid=root;" +
                    "pwd=Starwars2;database=restauracja";

                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                int ilosc_nowa = int.Parse(nowa_ilosc.Text);
                int ilosc_dodac = int.Parse(dodaj_ilosc.Text);

                if (ilosc_nowa != 0 && ilosc_dodac == 0)
                {
                    MySqlCommand command;
                    MySqlDataReader reader;
                    string sql;

                    sql = "CALL aktualizuj_skladnik(" + Id_skladnik + ", " + ilosc_nowa + ", \"zmien\");";
                    command = new MySqlCommand(sql, conn);
                    reader = command.ExecuteReader();
                    reader.Close();
                    Close();
                }
                else if(ilosc_dodac != 0 && ilosc_nowa == 0)
                {
                    MySqlCommand command;
                    MySqlDataReader reader;
                    string sql;

                    sql = "CALL aktualizuj_skladnik(" + Id_skladnik + ", " + ilosc_dodac + ", \"dodaj\");";
                    command = new MySqlCommand(sql, conn);
                    reader = command.ExecuteReader();
                    reader.Close();
                    Close();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void load_informations(int Id)
        {
            MySqlConnection conn, conn2;
            string myConnectionString = "server=localhost;uid=root;" +
                "pwd=Starwars2;database=restauracja";

            conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();

            MySqlCommand command, command2;
            MySqlDataReader reader, reader2;
            string sql, sql2;
            string[] Output = new string[6];

            sql = "SELECT * FROM skladnik";
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            List<Skladnik_Lista> SkladnikList = new List<Skladnik_Lista>();

            while (reader.Read())
            {
                if (int.Parse(reader.GetValue(0) + "") == Id)
                {
                    Output[0] = reader.GetValue(0) + "";                             // Id_Skladnik
                    Output[1] = reader.GetValue(1).ToString().ToUpper() + "";        // Nazwa
                    Output[2] = reader.GetValue(2) + "";                             // Ilosc
                    Output[3] = reader.GetValue(3) + "";                             // Id_jednostka

                    sql2 = "SELECT * FROM tabela_jednostka";
                    conn2 = new MySqlConnection();
                    conn2.ConnectionString = myConnectionString;
                    conn2.Open();
                    command2 = new MySqlCommand(sql2, conn2);
                    reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        if (reader2.GetValue(0).ToString() == Output[3])
                        {
                            Output[3] = reader2.GetValue(1).ToString();         // zamiast Id_Jednostka przypisujemy rzeczywistą jednostkę (szt, l, kg)
                        }
                    }
                    conn2.Close();

                    Output[4] = reader.GetValue(4) + "";                             // Cena_Za_Jednostke
                    Output[5] = reader.GetValue(5) + "";                             // Czy_Widoczn_W_Menu
                    //SkladnikList.Add(new Skladnik_Lista()
                    //{
                    //    Id_Skladnik = Output[0],
                    //    Nazwa = Output[1],
                    //    Ilosc = Output[2],
                    //    Id_Jednostka = Output[3],
                    //    Cena_Za_Jednostke = Output[4],
                    //    Czy_Widoczn_W_Menu = Output[5]
                    //});
                }
            }
            nazwa_txt.Text = Output[1];
            jednostka_txt1.Text = Output[3];
            jednostka_txt2.Text = Output[3];
            reader.Close();
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
