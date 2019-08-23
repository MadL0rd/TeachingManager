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
        public MainWindow()
		{
            this.InitializeComponent();
        }

        private void Window_Activated(object sender, System.EventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}