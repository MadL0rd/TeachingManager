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

using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace StartWindow
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindowStudent : Window
    {
        public OleDbConnection myConnection;
        public static string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= "+System.AppDomain.CurrentDomain.BaseDirectory+"\\AducationBase.accdb;";
        public WorkWindowStudent()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            HalloBox.Text += StartWindow.Data.StudentUsr.Name + " " + StartWindow.Data.StudentUsr.Patronymic;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            myConnection.Close();
        }
        
        private void HideAllGrids()
        {
            AnswerGrid.Visibility = Visibility.Hidden;
            TasksViewGrid.Visibility = Visibility.Hidden;
            JournalGrid.Visibility = Visibility.Hidden;
        }
        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            HideAllGrids();
            AnswerGrid.Visibility = Visibility.Visible;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HideAllGrids();
            UsrIDBuff.Text = "1";
            TasksViewGrid.Visibility = Visibility.Visible;
        }


        private void SandTask(object sender, RoutedEventArgs e)
        {
            Data.NewTaskAnswer.AnswerText = AnswerText.Text;
            if (Data.NewTaskAnswer.UnloadAnswer())
            {
                System.Windows.MessageBox.Show("Ответ успешно отправлен!", "Поздравляем!");
            }
            else
            {
                System.Windows.MessageBox.Show("Заполните поле ответа!");
            }
        }

        private void AddFileGialog(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Картинки(*.JPG;*.PNG)|*.JPG;*.PNG" + "|Все файлы (*.*)|*.* ";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            myDialog.ShowDialog();
            string buff = myDialog.FileName;
            if (buff != "")
            {
                StartWindow.Data.TaskFileImage buffImage = new Data.TaskFileImage(buff);
                StartWindow.Data.NewTaskAnswer.AnswerFiles.Add(buffImage);
                StartWindow.ViewModel.TasksViewModelStudent.TaskFilesViewBuff.Refresh();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubjectComboBox1.Text = "";
        }

        private void ViewImageFromBuff(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Image b = sender as System.Windows.Controls.Image;
            if (b != null)
            {
                ImageForView.Source = b.Source;
                ImageViewGrid.Visibility = Visibility.Visible;
            }
        }

        private void ImageForView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImageViewGrid.Visibility = Visibility.Hidden;
        }

        private void AnswerTheTask(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button b = sender as System.Windows.Controls.Button;
            Data.Tasks data = b.DataContext as Data.Tasks;

            HideAllGrids();
            Data.NewTaskAnswer.StudentID = Data.StudentUsr.ID;
            Data.NewTaskAnswer.TaskID = data.ID;
            Data.NewTaskAnswer.TeacherID = data.TeacherID;

            CurrentDateBeginStr.Text = data.DateBeginStr;
            CurrentDateEndStr.Text = data.DateEndStr;
            CurrentIMGS.Source = data.IMGS;
            CurrentSubject.Text = data.Subject;
            CurrentTaskText.Text = data.TaskText;
            CurrentTitle.Text = data.Title;
            CurrentLine.Visibility = Visibility.Visible;

            AnswerGrid.Visibility = Visibility.Visible;
        }

        private void LoadJournal(object sender, RoutedEventArgs e)
        {
            if ( JSubjectComboBox.Text == "") 
            {
                System.Windows.MessageBox.Show("Вам нужно выбрать предмет для просмотра!");
                return;
            }

            int idSubject = Data.TeacherUsr.GetIDWithText("Список предметов", "Предмет", JSubjectComboBox.Text);



            OleDbConnection connection = new OleDbConnection(connectString);
            string query = "TRANSFORM First(Ответы.Оценка) AS [First-Оценка] " +
                "SELECT[ДанныеУчеников]![Имя] + \" \" +[ДанныеУчеников]![Отчество] + \" \" +[ДанныеУчеников]![Фамилия] AS ФИО " +
                "FROM Задания INNER JOIN(ДанныеУчеников INNER JOIN Ответы ON ДанныеУчеников.ID = Ответы.УченикID) ON Задания.ID = Ответы.ЗаданиеID " +
                "WHERE(((ДанныеУчеников.Класс) = " + Data.StudentUsr.KlassID + ") AND((Задания.Предмет) = " + idSubject +")) " +
                "GROUP BY[ДанныеУчеников]![Имя] + \" \" +[ДанныеУчеников]![Отчество] + \" \" +[ДанныеУчеников]![Фамилия], ДанныеУчеников.Класс, Задания.Предмет " +
                "PIVOT Задания.Тема;";

            OleDbCommand Cmd = new OleDbCommand();
            Cmd.Connection = connection;
            Cmd.CommandText = query;
            OleDbDataAdapter DataAdap = new OleDbDataAdapter(Cmd);

            System.Data.DataTable dtRecord = new System.Data.DataTable();
            DataAdap.Fill(dtRecord);
            JournalDataGrid.ItemsSource = dtRecord.DefaultView;

            PrintButton.IsEnabled = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            HideAllGrids();
            JournalGrid.Visibility = Visibility.Visible;
        }


        private void PrintJ(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog printDialog = new System.Windows.Controls.PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(JournalDataGrid, "Распечатка журнала");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HideAllGrids();
            JournalGrid.Visibility = Visibility.Visible;
        }
    }
}
