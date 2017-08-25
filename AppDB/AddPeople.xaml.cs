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
using System.Data.SQLite;

namespace AppDB
{
    /// <summary>
    /// Логика взаимодействия для AddPeople.xaml
    /// </summary>
    public partial class AddPeople : Window
    {
        public AddPeople()
        {
            InitializeComponent();
        }

        string dbConnectionString = @"Data Source = people.db; Version=3;";

        private void button_closeAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_addData_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteconn = new SQLiteConnection(dbConnectionString);
            try
            {
                sqliteconn.Open();
                string Query = "insert into People (firstName, lastName, birthday, adress, home_phone, work_phone) values" +
                    " ('"+ this.txt_firstName .Text+ "', '" + this.txt_lastName.Text + "', '" + this.txt_birthday.Text.ToString() + "', '" + this.txt_adress.Text + "', '" + this.txt_homePhone.Text+"', '" + this.txt_workPhone.Text +"')";

                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteconn);

                createCommand.ExecuteNonQuery();
                MessageBox.Show("Добавлено!");
                sqliteconn.Close();
                txt_firstName.Clear();
                txt_lastName.Clear();
                txt_birthday.Clear();
                txt_adress.Clear();
                txt_homePhone.Clear();
                txt_workPhone.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteconn = new SQLiteConnection(dbConnectionString);
            try
            {
                sqliteconn.Open();
                string Query = "update People set firstName='" + this.txt_firstName.Text + "', lastName='" + this.txt_lastName.Text + "', birthday='" + this.txt_birthday.Text + "', adress='" + this.txt_adress.Text + "', home_phone='" + this.txt_homePhone.Text + "', work_phone='" + this.txt_workPhone.Text + "' where firstName='" + this.txt_firstName.Text + "'";

                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteconn);

                createCommand.ExecuteNonQuery();
                MessageBox.Show("Обновлено!");
                sqliteconn.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteconn = new SQLiteConnection(dbConnectionString);
            try
            {
                sqliteconn.Open();
                string Query = "delete from People where firstName = '" + this.txt_firstName + "'";

                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteconn);

                createCommand.ExecuteNonQuery();
                MessageBox.Show("Удалено!");
                sqliteconn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
