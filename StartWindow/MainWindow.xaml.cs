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
using System.Data.OleDb;


namespace StartWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private OleDbConnection myConnection;
        public static string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= "+System.AppDomain.CurrentDomain.BaseDirectory+"\\AducationBase.accdb;";
        public static string userID;

        
        public MainWindow()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        public bool LoginCheck(string login, string password)
        {
            string query = "SELECT DISTINCTROW ДанныеУчеников.ID FROM ДанныеУчеников WHERE(((ДанныеУчеников.Зарегистрирован) = True)) GROUP BY ДанныеУчеников.ID, ДанныеУчеников.Логин, ДанныеУчеников.Пароль HAVING(((ДанныеУчеников.Логин) =\"" + login + "\") AND((ДанныеУчеников.Пароль) =\"" + password + "\"));";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            string answer;
            try
            {
                answer = command.ExecuteScalar().ToString();
            }catch
            {
                answer = "0";
            }

            if (answer != "0")
            {
                userID = answer;
                return true;
            }

            query = "SELECT DISTINCTROW Преподаватели.ID FROM Преподаватели WHERE(((Преподаватели.Зарегистрирован) = True)) GROUP BY Преподаватели.ID, Преподаватели.Логин, Преподаватели.Пароль HAVING(((Преподаватели.Логин) =\"" + login + "\") AND((Преподаватели.Пароль) =\"" + password + "\"));";
            command = new OleDbCommand(query, myConnection);
            try
            {
                answer = command.ExecuteScalar().ToString();
            }
            catch
            {
                answer = "0";
            }

            if (answer != "0")
            {
                userID = 't'+answer;
                return true;
            }
            else return false;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            // заркываем соединение с БД
            myConnection.Close();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            bool checkData = LoginCheck(LoginBox.Text, PasswordBox.Password);
            if (checkData)
            {
                if (userID[0] != 't')
                {
                    StartWindow.ViewModel.TasksViewModelStudent.SetUsrID(userID);
                    StartWindow.WorkWindowStudent Window = new StartWindow.WorkWindowStudent();
                    Window.Show();
                    this.Close();
                }
                else
                {
                    userID = userID.Substring(1);
                    StartWindow.ViewModel.TasksViewModel.SetUsrID(userID);
                    WorkWindow Window = new WorkWindow();
                    Window.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Введены некорректные данные", "!!!Внимание!!!");
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 Window = new Window1();
            Window.Show();
            this.Close();
        }
    }
}
