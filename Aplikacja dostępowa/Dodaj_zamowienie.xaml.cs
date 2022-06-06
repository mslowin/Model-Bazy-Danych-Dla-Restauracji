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
        public List<Potrawy_Lista> PomList = new List<Potrawy_Lista>();
        public List<int> Id_potraw_do_zamowienia = new List<int>();

        public Dodaj_zamowienie()
        {
            PomList = GetPomList();

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

        public List<Potrawy_Lista> GetPomList()
        {
            return PomList;
        }

        private void dodaj_potrawe_Click(object sender, RoutedEventArgs e)
        {
            Button clickbtn = sender as Button;

            string index = clickbtn.ToString();
            index = index.Remove(0, 31);

            int intIndex;
            intIndex = Int32.Parse(index); // intIndex jest w tym miejscu Id_potrawa, na ktora sie kliklo
            Id_potraw_do_zamowienia.Add(intIndex);

            MySqlConnection conn;
            string myConnectionString = "server=localhost;uid=root;" +
                "pwd=Starwars2;database=restauracja";

            conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();

            MySqlCommand command;
            MySqlDataReader reader;
            string sql;
            string[] Output = new string[5];

            sql = "SELECT * FROM potrawa WHERE Id_Potrawa = " + intIndex + ";"; // zamówienia w lokalu (numer stolu > 0)
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            List<Potrawy_Lista> PotrawaList = new List<Potrawy_Lista>();
            PotrawaList.AddRange(PomList);

            
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            string time = year + "." + month + "." + day;

            while (reader.Read())
            {
                Output[0] = reader.GetValue(0) + "";                        //ID
                Output[1] = reader.GetValue(1) + "";                        //nazwa
                Output[2] = "Rodzaj diety: " + reader.GetValue(3) + "";     //dieta
                Output[3] = reader.GetValue(4) + " zł";                     //cena
                Output[4] = time;                                           //data
                PotrawaList.Add(new Potrawy_Lista() { Id_Potrawa = Output[0], Nazwa = Output[1], Id_Diety = Output[2], Cena = Output[3], Data = Output[4] });
                PomList.Add(new Potrawy_Lista() { Id_Potrawa = Output[0], Nazwa = Output[1], Id_Diety = Output[2], Cena = Output[3], Data = Output[4] });
                //GlobalVariables.TworzenieZamowienieList.Add(new Potrawy_Lista() { Id_Potrawa = Output[0], Nazwa = Output[1], Id_Diety = Output[2], Cena = Output[3] });
            }
            reader.Close();

            UserList_short.ItemsSource = PotrawaList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string stolik_text = stolik.Text;
            string lokal_text = lokal.Text;
            string ulica_text = ulica.Text;
            string budynek_text = budynek.Text;
            //DateTime data = DateTime.Parse(PomList[0].Data);
            string data = PomList[0].Data;

            if (stolik_text == "") stolik_text = "NULL";
            if (lokal_text == "") lokal_text = "NULL";
            if (ulica_text == "") ulica_text = "NULL";
            if (budynek_text == "") budynek_text = "NULL";

            MySqlConnection conn;
            string myConnectionString = "server=localhost;uid=root;" +
                "pwd=Starwars2;database=restauracja";

            conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();

            MySqlCommand command;
            string query = "CALL dodaj_zamowienie(" + stolik_text + ",\"" + data + "\"," + ulica_text + "," + budynek_text + "," + lokal_text + ",1,0);";
            //Console.WriteLine(query);
            command = new MySqlCommand(query, conn);
            _ = command.ExecuteReader();
            conn.Close();

            foreach (var i in Id_potraw_do_zamowienia) // dodawanie do zamowienia (tego stworzonego przed chwila) potraw dodanych wczesniej
            {
                conn.Open();
                //Console.WriteLine(i);
                string q = "CALL dodaj_relacje_zamowienie_potrawa(" + i + ");";
                command = new MySqlCommand(q, conn);
                _ = command.ExecuteReader();
                conn.Close();
            }

            Id_potraw_do_zamowienia.Clear();

            this.Close();
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
            public string Data { get; set; }
            public int enumNumber { get; set; }
        }

        
    }
}
