using System;
using Restauracja_Bazy_Danych.Helper;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Restauracja_Bazy_Danych
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DBHelper.EstablishConnection();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn;
            string myConnectionString = "server=localhost;uid=root;" +
                "pwd=Starwars2;database=restauracja";

            conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();

            MySqlCommand command;
            MySqlDataReader reader;
            string sql, Output = " ";

            sql = "SELECT * FROM potrawa";
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Output = Output + reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3) + " " + reader.GetValue(4) + "\n";
            }
            reader.Close();

            textbox1.Text = Output;

            conn.Close();
            Console.WriteLine("The database has been closed!");

            conn.Dispose();
            Console.WriteLine("The database connection has been disposed!");
            Console.WriteLine("Connection State: " + conn.State.ToString());
        }
    }
}
