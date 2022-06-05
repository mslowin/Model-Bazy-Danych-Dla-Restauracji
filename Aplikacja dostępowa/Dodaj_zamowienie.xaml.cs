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
    /// Logika interakcji dla klasy Dodaj_zamowienie.xaml
    /// </summary>
    public partial class Dodaj_zamowienie : Window
    {
        public Dodaj_zamowienie()
        {
            InitializeComponent();
            loadStackPanelData_Przystawki();
            loadStackPanelData_Zupy();
            loadStackPanelData_Dania_Glowne();
            loadStackPanelData_Pizza();
            loadStackPanelData_Dodatek();
            loadStackPanelData_Deser();
            loadStackPanelData_Bezalkoholowy();
            loadStackPanelData_Alkoholowy();
        }

        private void dodaj_potrawe_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void loadStackPanelData_Alkoholowy()
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

            sql = "SELECT * FROM potrawa WHERE Id_Rodzaj = 8;"; // zamówienia w lokalu (numer stolu > 0)
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            List<Potrawy_Lista> ZamowienieList = new List<Potrawy_Lista>();

            while (reader.Read())
            {
                Output[0] = reader.GetValue(0) + "";                        //ID
                Output[1] = reader.GetValue(1) + "";                        //nazwa
                Output[2] = "Rodzaj diety: " + reader.GetValue(3) + "";     //dieta
                Output[3] = reader.GetValue(4) + " zł";                     //cena
                ZamowienieList.Add(new Potrawy_Lista() { Id_Potrawa = Output[0], Nazwa = Output[1], Id_Diety = Output[2], Cena = Output[3] });

            }
            reader.Close();

            UserList_alkoholowy.ItemsSource = ZamowienieList;
            
        }

        private void loadStackPanelData_Bezalkoholowy()
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

            sql = "SELECT * FROM potrawa WHERE Id_Rodzaj = 7;"; // zamówienia w lokalu (numer stolu > 0)
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            List<Potrawy_Lista> ZamowienieList = new List<Potrawy_Lista>();

            while (reader.Read())
            {
                Output[0] = reader.GetValue(0) + "";                        //ID
                Output[1] = reader.GetValue(1) + "";                        //nazwa
                Output[2] = "Rodzaj diety: " + reader.GetValue(3) + "";     //dieta
                Output[3] = reader.GetValue(4) + " zł";                     //cena
                ZamowienieList.Add(new Potrawy_Lista() { Id_Potrawa = Output[0], Nazwa = Output[1], Id_Diety = Output[2], Cena = Output[3] });

            }
            reader.Close();

            UserList_bezalkoholowy.ItemsSource = ZamowienieList;
        }

        private void loadStackPanelData_Deser()
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

            sql = "SELECT * FROM potrawa WHERE Id_Rodzaj = 6;"; // zamówienia w lokalu (numer stolu > 0)
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            List<Potrawy_Lista> ZamowienieList = new List<Potrawy_Lista>();

            while (reader.Read())
            {
                Output[0] = reader.GetValue(0) + "";                        //ID
                Output[1] = reader.GetValue(1) + "";                        //nazwa
                Output[2] = "Rodzaj diety: " + reader.GetValue(3) + "";     //dieta
                Output[3] = reader.GetValue(4) + " zł";                     //cena
                ZamowienieList.Add(new Potrawy_Lista() { Id_Potrawa = Output[0], Nazwa = Output[1], Id_Diety = Output[2], Cena = Output[3] });

            }
            reader.Close();

            UserList_deser.ItemsSource = ZamowienieList;
        }

        private void loadStackPanelData_Dodatek()
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

            sql = "SELECT * FROM potrawa WHERE Id_Rodzaj = 5;"; // zamówienia w lokalu (numer stolu > 0)
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            List<Potrawy_Lista> ZamowienieList = new List<Potrawy_Lista>();

            while (reader.Read())
            {
                Output[0] = reader.GetValue(0) + "";                        //ID
                Output[1] = reader.GetValue(1) + "";                        //nazwa
                Output[2] = "Rodzaj diety: " + reader.GetValue(3) + "";     //dieta
                Output[3] = reader.GetValue(4) + " zł";                     //cena
                ZamowienieList.Add(new Potrawy_Lista() { Id_Potrawa = Output[0], Nazwa = Output[1], Id_Diety = Output[2], Cena = Output[3] });

            }
            reader.Close();

            UserList_dodatek.ItemsSource = ZamowienieList;
        }

        private void loadStackPanelData_Pizza()
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

            sql = "SELECT * FROM potrawa WHERE Id_Rodzaj = 4;"; // zamówienia w lokalu (numer stolu > 0)
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            List<Potrawy_Lista> ZamowienieList = new List<Potrawy_Lista>();

            while (reader.Read())
            {
                Output[0] = reader.GetValue(0) + "";                        //ID
                Output[1] = reader.GetValue(1) + "";                        //nazwa
                Output[2] = "Rodzaj diety: " + reader.GetValue(3) + "";     //dieta
                Output[3] = reader.GetValue(4) + " zł";                     //cena
                ZamowienieList.Add(new Potrawy_Lista() { Id_Potrawa = Output[0], Nazwa = Output[1], Id_Diety = Output[2], Cena = Output[3] });

            }
            reader.Close();

            UserList_pizza.ItemsSource = ZamowienieList;
        }

        private void loadStackPanelData_Dania_Glowne()
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

            sql = "SELECT * FROM potrawa WHERE Id_Rodzaj = 3;"; // zamówienia w lokalu (numer stolu > 0)
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            List<Potrawy_Lista> ZamowienieList = new List<Potrawy_Lista>();

            while (reader.Read())
            {
                Output[0] = reader.GetValue(0) + "";                        //ID
                Output[1] = reader.GetValue(1) + "";                        //nazwa
                Output[2] = "Rodzaj diety: " + reader.GetValue(3) + "";     //dieta
                Output[3] = reader.GetValue(4) + " zł";                     //cena
                ZamowienieList.Add(new Potrawy_Lista() { Id_Potrawa = Output[0], Nazwa = Output[1], Id_Diety = Output[2], Cena = Output[3] });

            }
            reader.Close();

            UserList_dania_glowne.ItemsSource = ZamowienieList;
        }

        private void loadStackPanelData_Zupy()
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

            sql = "SELECT * FROM potrawa WHERE Id_Rodzaj = 2;"; // zamówienia w lokalu (numer stolu > 0)
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            List<Potrawy_Lista> ZamowienieList = new List<Potrawy_Lista>();

            while (reader.Read())
            {
                Output[0] = reader.GetValue(0) + "";                        //ID
                Output[1] = reader.GetValue(1) + "";                        //nazwa
                Output[2] = "Rodzaj diety: " + reader.GetValue(3) + "";     //dieta
                Output[3] = reader.GetValue(4) + " zł";                     //cena
                ZamowienieList.Add(new Potrawy_Lista() { Id_Potrawa = Output[0], Nazwa = Output[1], Id_Diety = Output[2], Cena = Output[3] });

            }
            reader.Close();

            UserList_zupy.ItemsSource = ZamowienieList;
        }

        private void loadStackPanelData_Przystawki()
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

            sql = "SELECT * FROM potrawa WHERE Id_Rodzaj = 1;"; // zamówienia w lokalu (numer stolu > 0)
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            List<Potrawy_Lista> ZamowienieList = new List<Potrawy_Lista>();

            while (reader.Read())
            {
                Output[0] = reader.GetValue(0) + "";                        //ID
                Output[1] = reader.GetValue(1) + "";                        //nazwa
                Output[2] = "Rodzaj diety: " + reader.GetValue(3) + "";     //dieta
                Output[3] = reader.GetValue(4) + " zł";                     //cena
                ZamowienieList.Add(new Potrawy_Lista() { Id_Potrawa = Output[0], Nazwa = Output[1], Id_Diety = Output[2], Cena = Output[3] });

            }
            reader.Close();

            UserList_przystawki.ItemsSource = ZamowienieList;
        }

        public class Potrawy_Lista
        {
            public string Id_Potrawa { get; set; }
            public string Nazwa { get; set; }
            public string Id_Diety { get; set; }
            public string Cena { get; set; }
            public int enumNumber { get; set; }
        }
    }
}
