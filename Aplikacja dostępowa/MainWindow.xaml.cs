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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Restauracja_Bazy_Danych.Helper;
using MySql.Data.MySqlClient;

namespace Restauracja_Bazy_Danych
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /** Kody poszczególnych posad - do logowania do osobnych okien
         * 1234 - Kelner
         * 4321 - Barman
         * 5678 - Kucharz
         * 8765 - Kierowca
         * 0000 - Kierownik
        */
        private string[] codes = new string[5] { "1234", "4321", "5678", "8765", "0000"};

        public MainWindow()
        {
            InitializeComponent();
            DBHelper.EstablishConnection();
        }

        private void Button7(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("7");
            Button button = (Button)sender;
            pinBox.Password += button.Content.ToString();
        }
        private void Button8(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("8");
            Button button = (Button)sender;
            pinBox.Password += button.Content.ToString();
        }
        private void Button9(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("9");
            Button button = (Button)sender;
            pinBox.Password += button.Content.ToString();
        }
        private void Button4(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("4");
            Button button = (Button)sender;
            pinBox.Password += button.Content.ToString();
        }
        private void Button5(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("5");
            Button button = (Button)sender;
            pinBox.Password += button.Content.ToString();
        }
        private void Button6(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("6");
            Button button = (Button)sender;
            pinBox.Password += button.Content.ToString();
        }
        private void Button1(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("1");
            Button button = (Button)sender;
            pinBox.Password += button.Content.ToString();
        }
        private void Button2(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("2");
            Button button = (Button)sender;
            pinBox.Password += button.Content.ToString();
        }
        private void Button3(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("3");
            Button button = (Button)sender;
            pinBox.Password += button.Content.ToString();
        }
        private void ButtonC(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("C");
            if (pinBox.Password.Length > 0)
            {
                pinBox.Password = pinBox.Password.Remove(pinBox.Password.Length - 1, 1);
            }
        }
        private void Button0(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("0");
            Button button = (Button)sender;
            pinBox.Password += button.Content.ToString();
        }
        private void ButtonOk(object sender, RoutedEventArgs e)
        {
            string Password = pinBox.Password;
            try
            {
                if (Password == codes[0])
                {
                    Console.WriteLine("KELNER");
                    kelner_window testwindow = new kelner_window();
                    Content = testwindow.Content;
                    //testwindow.ShowDialog();
                }
                else if (Password == codes[1])
                {
                    Console.WriteLine("BARMAN");
                }
                else if (Password == codes[2])
                {
                    Console.WriteLine("KUCHARZ");
                }
                else if (Password == codes[3])
                {
                    Console.WriteLine("KIEROWCA");
                }
                else if (Password == codes[4])
                {
                    Console.WriteLine("KIEROWNIK");
                    Kierownik_window testwindow2 = new Kierownik_window();
                    Content = testwindow2.Content;
                    //_ = testwindow2.ShowDialog();
                }
                else if (pinBox.Password.Length > 0)
                {
                    _ = MessageBox.Show("Niepoprawne logowanie!", "Wystąpił błąd",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            Console.WriteLine("OK");
        }
    }
}
