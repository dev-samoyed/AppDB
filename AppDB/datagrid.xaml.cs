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
using System.Data;

namespace AppDB
{
    /// <summary>
    /// Логика взаимодействия для datagrid.xaml
    /// </summary>
    public partial class datagrid : Window
    {
        public datagrid()
        {
            InitializeComponent();
            dgGrid();
        }

        string dbConnectionString = @"Data Source = people.db; Version=3;";

        void dgGrid()
        {
            SQLiteConnection sqliteconn = new SQLiteConnection(dbConnectionString);
            try
            {
                sqliteconn.Open();
                string Query = "select * from People";

                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteconn);
                createCommand.ExecuteNonQuery();

                SQLiteDataAdapter dataAde = new SQLiteDataAdapter(createCommand);
                DataTable dt = new DataTable("People");
                dataAde.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                dataAde.Update(dt);



                sqliteconn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
