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
    /// Логика взаимодействия для SearchPeople.xaml
    /// </summary>
    public partial class SearchPeople : Window
    {
        public SearchPeople()
        {
            InitializeComponent();
            
        }

        string dbConnectionString = @"Data Source = people.db; Version=3;";

        private void btn_closeThisPage_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       void fill_listBox()
        {
            SQLiteConnection sqliteconn = new SQLiteConnection(dbConnectionString);
            try
            {
                sqliteconn.Open();
                string Query = "select * from People ";

                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteconn);

                SQLiteDataReader dr = createCommand.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(1);
                    string last_name = dr.GetString(2);
                    string birthday = dr.GetString(3);
                    string adress = dr.GetString(4);
                    int homePhone = dr.GetInt32(5);
                    int workPhone = dr.GetInt32(6);
                    listBox.Items.Add(name + " " + last_name + " " + birthday + " " + adress + " " + homePhone + " " + workPhone);
                }
                sqliteconn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_showAll_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            fill_listBox();
        }

        private void load_table_Click(object sender, RoutedEventArgs e)
        {
            datagrid dg = new datagrid();
            dg.ShowDialog();
        }

       
    }
}
