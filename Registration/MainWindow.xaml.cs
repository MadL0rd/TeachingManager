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

namespace Registration
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private OleDbConnection myConnection;
        public static string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= D:\\AducationBase.accdb;";
        public static string userID;


        public MainWindow()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        public bool RegistrCheck(string name, string surname, string patronymic)
        {
            string query = "SELECT DISTINCTROW ДанныеУчеников.Зарегистрирован FROM ДанныеУчеников GROUP BY ДанныеУчеников.Зарегистрирован, ДанныеУчеников.Имя, ДанныеУчеников.Фамилия, ДанныеУчеников.Отчество HAVING(((ДанныеУчеников.Имя) =\"" + name + "\") AND((ДанныеУчеников.Фамилия) =\"" + surname + "\") AND((ДанныеУчеников.Отчество) =\"" + patronymic + "\"));";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);
            string answer;
            try
            {
                answer = command.ExecuteScalar().ToString();
            }
            catch
            {
                answer = "no inform";
                MessageBox.Show("Человека с таким ФИО нет в списке!", "!!!Внимание!!!");
            }

            if (answer == "False") return true;
            else return false;
        }
        public bool LoginCheck(string login, string password)
        {
            string query = "SELECT DISTINCTROW Count(ДанныеУчеников.Зарегистрирован) AS [Count-Зарегистрирован] FROM ДанныеУчеников WHERE(((ДанныеУчеников.Зарегистрирован) = True)) GROUP BY ДанныеУчеников.Логин, ДанныеУчеников.Пароль HAVING(((ДанныеУчеников.Логин) =\"" + login + "\") AND((ДанныеУчеников.Пароль) =\"" + password + "\"));";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);
            string answer;
            try
            {
                answer = command.ExecuteScalar().ToString();
            }
            catch
            {
                answer = "0";
            }

            if (answer != "0") return true;
            else return false;
        }
        public void Registr()
        {
            string query = "UPDATE ДанныеУчеников SET ДанныеУчеников.Зарегистрирован = True, ДанныеУчеников.Логин = \"" + LoginBox.Text + "\", ДанныеУчеников.Пароль = \"" + PasswordBox.Password + "\", ДанныеУчеников.Телефон = \"" + PhoneBox.Text + "\", ДанныеУчеников.Почта = \"" + MailBox.Text + "\" WHERE(((ДанныеУчеников.Имя) = \"" + NameBox.Text + "\") AND((ДанныеУчеников.Фамилия) = \"" + SurnameBox.Text + "\") AND((ДанныеУчеников.Отчество) = \"" + PatronymicBox.Text + "\"));";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteScalar();
             MessageBox.Show("Регистрация прошла успешно!", "!!!Поздравляю!!!");
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
            if (PasswordBox.Password.Length < 5)
            {
                MessageBox.Show("Введите пароль должен содержать минимум 5 символов!", "!!!Внимание!!!");
                return;
            }
            if (PasswordBox.Password != PasswordBox1.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "!!!Внимание!!!");
                return;
            }
            if (NameBox.Text.Length == 0 || SurnameBox.Text.Length == 0 || PatronymicBox.Text.Length == 0 || PhoneBox.Text.Length == 0|| MailBox.Text.Length == 0)
            {
                MessageBox.Show("Вам нужно заполнить все поля!", "!!!Внимание!!!");
                return;
            }

            bool checkData = RegistrCheck(NameBox.Text, SurnameBox.Text, PatronymicBox.Text);
            if (!checkData)
            {
                MessageBox.Show("Введены некорректные данные, рагистрация невозможна!", "!!!Внимание!!!");
            }
            checkData = LoginCheck(LoginBox.Text, PasswordBox.Password);

            if(checkData)
            {
                MessageBox.Show("Этот человек уже зарегистрирован!", "!!!Внимание!!!");
                return;
            }

            Registr();


            this.Close();



        }
    }
}
