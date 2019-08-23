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
using System.Data.OleDb;


namespace StartWindow
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        private OleDbConnection myConnection;
        public static string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= "+System.AppDomain.CurrentDomain.BaseDirectory+"\\AducationBase.accdb;";
        public static string userID;
        private bool teacher = false;


        public Window1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        public bool RegistrCheck(string name, string surname, string patronymic)
        {
            string query = "SELECT DISTINCTROW ДанныеУчеников.Зарегистрирован FROM ДанныеУчеников GROUP BY ДанныеУчеников.Зарегистрирован, ДанныеУчеников.Имя, ДанныеУчеников.Фамилия, ДанныеУчеников.Отчество HAVING(((ДанныеУчеников.Имя) =\"" + name + "\") AND((ДанныеУчеников.Фамилия) =\"" + surname + "\") AND((ДанныеУчеников.Отчество) =\"" + patronymic + "\"));";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            string answer;
            try
            {
                answer = command.ExecuteScalar().ToString();
            }
            catch
            {
                answer = "no inform";
            }

            if (answer == "False") return true;
            query = "SELECT DISTINCTROW Преподаватели.Зарегистрирован FROM Преподаватели GROUP BY Преподаватели.Зарегистрирован, Преподаватели.Имя, Преподаватели.Фамилия, Преподаватели.Отчество HAVING(((Преподаватели.Имя) =\"" + name + "\") AND((Преподаватели.Фамилия) =\"" + surname + "\") AND((Преподаватели.Отчество) =\"" + patronymic + "\"));";
            command = new OleDbCommand(query, myConnection);
            try
            {
                answer = command.ExecuteScalar().ToString();
            }
            catch
            {
                answer = "no inform";
            }

            if (answer == "False")
            {
                teacher = true;
                return true;
            }
            else return false;
        }
        public bool LoginCheck(string login, string password)
        {
            string query = "SELECT DISTINCTROW Count(ДанныеУчеников.Зарегистрирован) AS [Count-Зарегистрирован] FROM ДанныеУчеников WHERE(((ДанныеУчеников.Зарегистрирован) = True)) GROUP BY ДанныеУчеников.Логин, ДанныеУчеников.Пароль HAVING(((ДанныеУчеников.Логин) =\"" + login + "\") AND((ДанныеУчеников.Пароль) =\"" + password + "\"));";
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
            query = "SELECT DISTINCTROW Count(Преподаватели.Зарегистрирован) AS [Count-Зарегистрирован] FROM Преподаватели WHERE(((Преподаватели.Зарегистрирован) = True)) GROUP BY Преподаватели.Логин, Преподаватели.Пароль HAVING(((Преподаватели.Логин) =\"" + login + "\") AND((Преподаватели.Пароль) =\"" + password + "\"));";
            command = new OleDbCommand(query, myConnection);
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
            if (teacher) query = "UPDATE Преподаватели SET Преподаватели.Зарегистрирован = True, Преподаватели.Логин = \"" + LoginBox.Text + "\", Преподаватели.Пароль = \"" + PasswordBox.Password + "\", Преподаватели.Телефон = \"" + PhoneBox.Text + "\", Преподаватели.Почта = \"" + MailBox.Text + "\" WHERE(((Преподаватели.Имя) = \"" + NameBox.Text + "\") AND((Преподаватели.Фамилия) = \"" + SurnameBox.Text + "\") AND((Преподаватели.Отчество) = \"" + PatronymicBox.Text + "\"));";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteScalar();
            MessageBox.Show("Регистрация прошла успешно!", "!!!Поздравляю!!!");
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
            if (NameBox.Text.Length == 0 || SurnameBox.Text.Length == 0 || PatronymicBox.Text.Length == 0 || PhoneBox.Text.Length == 0 || MailBox.Text.Length == 0)
            {
                MessageBox.Show("Вам нужно заполнить все поля!", "!!!Внимание!!!");
                return;
            }
            if (PasswordBox.Password.Length < 5)
            {
                MessageBox.Show("Пароль должен содержать минимум 5 символов!", "!!!Внимание!!!");
                return;
            }
            if (PasswordBox.Password != PasswordBox1.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "!!!Внимание!!!");
                return;
            }
            bool checkData = RegistrCheck(NameBox.Text, SurnameBox.Text, PatronymicBox.Text);
            if (!checkData)
             {
                MessageBox.Show("Человека с таким ФИО нет в списке, либо он уже зарегистрирован!", "!!!Внимание!!!");
                return;
            }
            checkData = LoginCheck(LoginBox.Text, PasswordBox.Password);

            if (checkData)
            {
                MessageBox.Show("Логин занят!", "!!!Внимание!!!");
                return;
            }

            Registr();

            MainWindow Window = new MainWindow();
            Window.Show();
            this.Close();



        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Window = new MainWindow();
            Window.Show();
            this.Close();
        }
    }
}
