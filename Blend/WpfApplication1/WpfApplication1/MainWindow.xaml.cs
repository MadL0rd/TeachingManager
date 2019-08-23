using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.OleDb;

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        // поле - ссылка на экземпляр класса OleDbConnection для соединения с БД
        private OleDbConnection myConnection;
        public static string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= D:\\AducationBase.accdb;";

        public MainWindow()
		{
            this.InitializeComponent();
            //Insert code required on object creation below this point.
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Window_Activated(object sender, System.EventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT Зарегистрирован FROM Данные учеников";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // выполняем запрос и выводим результат в textBox1
            TeachingManagerText.Text = command.ExecuteScalar().ToString();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            myConnection.Close();
        }
    }
}