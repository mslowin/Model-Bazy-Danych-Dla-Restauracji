﻿using System;
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
            LoadStackPanelData_SKladniki();
            LoadStackPanelData_Pracownicy();
        }

        private void informacje_Click(object sender, RoutedEventArgs e)
        {
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        private void LoadStackPanelData_Pracownicy()
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
            string[] Output = new string[8];

            sql = "SELECT * FROM pracownik";
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            List<Pracownik_Lista> PracownikList = new List<Pracownik_Lista>();

            while (reader.Read())
            {
                Output[0] = reader.GetValue(0) + "";                             // Id_Pracownika
                Output[1] = reader.GetValue(1) + "";                             // Imie
                Output[2] = reader.GetValue(2) + "";                             // Nazwisko
                Output[3] = reader.GetValue(3) + "";                             // Pesel
                Output[4] = reader.GetValue(4) + "";                             // Rok urodzenia
                Output[5] = reader.GetValue(5) + "";                             // Id_Posada

                sql2 = "SELECT * FROM tabela_posad";
                conn2 = new MySqlConnection
                {
                    ConnectionString = myConnectionString
                };
                conn2.Open();
                command2 = new MySqlCommand(sql2, conn2);
                reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2.GetValue(0).ToString() == Output[5])
                    {
                        Output[5] = reader2.GetValue(1).ToString();             // przypisanie Id_Posada rzeczywistej posady
                    }
                }
                conn2.Close();

                Output[6] = reader.GetValue(6) + "";                             // Zmiana (1 = pierwsza, 2 = druga)

                if (Output[6] == "1")
                {
                    Output[6] = "pierwsza";
                }
                if (Output[6] == "2")
                {
                    Output[6] = "druga";
                }

                Output[7] = reader.GetValue(7) + "";                             // Wynagrodzenie

                PracownikList.Add(new Pracownik_Lista()
                {
                    Id_Pracownika = Output[0],
                    Imie = Output[1],
                    Nazwisko = Output[2],
                    Pesel = Output[3],
                    RokUrodzenia = Output[4],
                    Posada = Output[5],
                    Zmiana = Output[6],
                    Wynagrodzenie = Output[7]
                });
            }
            reader.Close();

            UserList_pracownicy.ItemsSource = PracownikList;
        }

        private void dodaj_potrawe_Click(object sender, RoutedEventArgs e)
        {
            Button clickbtn = sender as Button;

            string index = clickbtn.ToString();
            index = index.Remove(0, 31);

            int intIndex;
            intIndex = Int32.Parse(index); //indeks zamowienia ktorego informacje chcemy wyswietlic

            Dodaj_skladnik DodajSkladnik = new Dodaj_skladnik(intIndex);
            DodajSkladnik.ShowDialog();
            LoadStackPanelData_SKladniki();
        }

        private void LoadStackPanelData_SKladniki()
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
                    if(reader2.GetValue(0).ToString() == Output[3])
                    {
                        Output[3] = reader2.GetValue(1).ToString();         // zamiast Id_Jednostka przypisujemy rzeczywistą jednostkę (szt, l, kg)
                    }
                }
                conn2.Close();

                Output[4] = reader.GetValue(4) + "";                             // Cena_Za_Jednostke
                Output[5] = reader.GetValue(5) + "";                             // Czy_Widoczn_W_Menu
                SkladnikList.Add(new Skladnik_Lista()
                {
                    Id_Skladnik = Output[0],
                    Nazwa = Output[1],
                    Ilosc = Output[2],
                    Id_Jednostka = Output[3],
                    Cena_Za_Jednostke = Output[4],
                    Czy_Widoczn_W_Menu = Output[5]
                });
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

        public class Pracownik_Lista
        {
            public string Id_Pracownika { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Pesel { get; set; }
            public string RokUrodzenia { get; set; }
            public string Posada { get; set; }
            public string Zmiana { get; set; }
            public string Wynagrodzenie { get; set; }
            public int enumNumber { get; set; }
        }
    }
}
