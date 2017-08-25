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

using System.Data.SQLite;

namespace AppDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dbConnectionString = @"Data Source = people.db; Version=3;";


        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteconn = new SQLiteConnection(dbConnectionString);
            try
            {
                sqliteconn.Open();
                string Query = "select * from Admin where username ='" + this.username1.Text + "' and password='" + this.password.Password + "' ";

                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteconn);

                createCommand.ExecuteNonQuery();
                SQLiteDataReader dr = createCommand.ExecuteReader();

                int count = 0;
                while (dr.Read())
                {
                    count++;
                }

                if (count == 1)
                {
                    MessageBox.Show("Username and Password is correct");
                    sqliteconn.Close();
                    Menu menu = new Menu();
                    menu.ShowDialog();//открываем окно меню

                }
                if (count > 1)
                {
                    MessageBox.Show("Duplicate Username and Password. Try again");

                }
                if (count < 1)
                {
                    MessageBox.Show("Username and Password is not correct");

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
