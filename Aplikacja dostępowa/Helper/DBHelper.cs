﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Restauracja_Bazy_Danych.Helper
{
    class DBHelper
    {
        private static MySqlConnection connection;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        /*
         * Job is to establish connection to the database
         */
        public static void EstablishConnection()
        {
            MySqlConnection conn;
            string myConnectionString = "server=localhost;uid=root;" +
                "pwd=Starwars2;database=restauracja";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                //Console.WriteLine("The database has been opened!");
                //Console.WriteLine("Connection State: " + conn.State.ToString());
                //Console.ReadLine();
                //MessageBoxButton button = MessageBoxButton.YesNoCancel;
                //MessageBoxImage icon = MessageBoxImage.Warning;
                //MessageBox.Show("Baza polaczona", "Connection", button, icon, MessageBoxResult.Yes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie dziala");
            }
        }

        public static MySqlCommand RunQuery(string query, string username)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return cmd;
        }
    }
}


