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
using System.Drawing.Printing;

namespace StartWindow
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        public OleDbConnection myConnection;
        public static string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= "+System.AppDomain.CurrentDomain.BaseDirectory+"\\AducationBase.accdb;";
        public WorkWindow()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            HalloBox.Text += StartWindow.Data.TeacherUsr.Name + " " + StartWindow.Data.TeacherUsr.Patronymic;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            myConnection.Close();
        }
        
        private void HideAllGrids()
        {
            GiveTaskGrid.Visibility = Visibility.Hidden;
            TasksViewGrid.Visibility = Visibility.Hidden;
            AnswerGrid.Visibility = Visibility.Hidden;
            MarkGrid.Visibility = Visibility.Hidden;
            JournalGrid.Visibility = Visibility.Hidden;
        }
        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            HideAllGrids();
            GiveTaskGrid.Visibility = Visibility.Visible;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HideAllGrids();
            UsrIDBuff.Text = "1";
            TasksViewGrid.Visibility = Visibility.Visible;
        }


        private void SandTask(object sender, RoutedEventArgs e)
        {


            if (KlassComboBox.Text!="" && SubjectComboBox.Text!= "" && DatePic.Text!="" && TitleBox.Text!="" && TaskText.Text!="")
            {
                int idKlass, idSubject, idTeacher, idSchool;
                idKlass = Data.TeacherUsr.GetIDWithText("Учебная программа", "Класс", KlassComboBox.Text);
                idSubject = Data.TeacherUsr.GetIDWithText("Список предметов", "Предмет", SubjectComboBox .Text);
                idTeacher = Data.TeacherUsr.ID;
                string DateBegin = Convert.ToString(DateTime.Today.ToString("dd.MM.yyyy"));
                string DateEnd = DatePic.Text;
                idSchool = Data.TeacherUsr.SchoolID;
                string title = TitleBox.Text;
                string task = TaskText.Text;


                if (Data.NewTask.TaskFiles.Count > 0)
                {
                    OleDbConnection connection = new OleDbConnection(connectString);
                    string query = "INSERT INTO Задания(Тема, [Дата выдачи], [Дата сдачи], Школа, Предмет, [Текст задания], Класс, Преподаватель, ДопФайлы) " +
                        "values( '" + title + "', '" + DateBegin + "', '" + DateEnd + "', '" + idSchool + "', '" + idSubject + "', '" + task + "', '" + idKlass + "', '" + idTeacher + "' , ? )";
                    OleDbCommand command = new OleDbCommand(query, connection);

                    OleDbParameter oleDbParameter = new OleDbParameter("ДопФайлы", OleDbType.VarBinary);
                    string fileName = StartWindow.Data.NewTask.TaskFiles[0].directory;                                                    //Путь к файлу
                    System.Drawing.Image image = System.Drawing.Image.FromFile(fileName);                                                 //Изображение из файла.
                    MemoryStream memoryStream = new MemoryStream();                                                                       //Поток в который запишем изображение
                    image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);                                                     //Сохраняем изображение в поток.
                    oleDbParameter.Value = memoryStream.ToArray();                                                                        //Устанавливаем значение параметра
                    command.Parameters.Add(oleDbParameter);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    memoryStream.Dispose();
                }
                else
                {

                    OleDbConnection connection = new OleDbConnection(connectString);
                    string query = "INSERT INTO Задания(Тема, [Дата выдачи], [Дата сдачи], Школа, Предмет, [Текст задания], Класс, Преподаватель) " +
                        "values( '" + title + "', '" + DateBegin + "', '" + DateEnd + "', '" + idSchool + "', '" + idSubject + "', '" + task + "', '" + idKlass + "', '" + idTeacher + "')";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
                KlassComboBox.Text = "";
                SubjectComboBox.Text = "" ;
                DatePic.Text = "" ;
                TitleBox.Text = "" ;
                TaskText.Text = "";
                Data.NewTask.TaskFiles.Clear();
                TaskViewList.ItemsSource = ViewModel.TasksViewModel.RefrashItems();
                (TaskViewList.ItemsSource as ICollectionView).Refresh();
                System.Windows.MessageBox.Show("Задание успешно выдано!", "Поздравляем!");
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
                StartWindow.Data.NewTask.TaskFiles.Add(buffImage);
                StartWindow.ViewModel.TasksViewModel.TaskFilesViewBuff.Refresh();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubjectComboBox1.Text = "";
            KlassComboBox1.Text = "";
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HideAllGrids();
            MarkGrid.Visibility = Visibility.Visible;
            AnswerGrid.Visibility = Visibility.Visible;
        }

        private void MarkAnswer(object sender, RoutedEventArgs e)
        {
            Data.Tasks buff = (sender as System.Windows.Controls.Button).DataContext as Data.Tasks;
            if (buff != null)
            {
                CurrentTaskView.ItemsSource = ViewModel.TasksViewModel.RefrashCurrentTask(buff);
                (CurrentTaskView.ItemsSource as ICollectionView).Refresh();
                CurrentTaskAnswerView.ItemsSource = ViewModel.TasksViewModel.RefrashCurrentTaskAnswers();
                (CurrentTaskAnswerView.ItemsSource as ICollectionView).Refresh();
                HideAllGrids();
                AnswerGrid.Visibility = Visibility.Visible;
                MarkGrid.Visibility = Visibility.Visible;
            }
        }
        private void MarkTheAnswer(object sender, RoutedEventArgs e)
        {
            if (MarkComboBox.Text!="")
            {
                ((sender as System.Windows.Controls.Button).DataContext as Data.Answer).MarkTheAnswer(MarkComboBox.Text, CommentBox.Text);
                (CurrentTaskAnswerView.ItemsSource as ICollectionView).Refresh();
            }
            else
            {
                System.Windows.MessageBox.Show("Оцените ответ!");
            }
        }

        private void LoadJournal(object sender, RoutedEventArgs e)
        {
            if (JKlassComboBox.Text == "" || JSubjectComboBox.Text == "") 
            {
                System.Windows.MessageBox.Show("Вам нужно выбрать класс и предмет для просмотра!");
                return;
            }

            int idKlass = Data.TeacherUsr.GetIDWithText("Учебная программа", "Класс", JKlassComboBox.Text);
            int idSubject = Data.TeacherUsr.GetIDWithText("Список предметов", "Предмет", JSubjectComboBox.Text);



            OleDbConnection connection = new OleDbConnection(connectString);
            string query = "TRANSFORM First(Ответы.Оценка) AS [First-Оценка] " +
                "SELECT[ДанныеУчеников]![Имя] + \" \" +[ДанныеУчеников]![Отчество] + \" \" +[ДанныеУчеников]![Фамилия] AS ФИО " +
                "FROM Задания INNER JOIN(ДанныеУчеников INNER JOIN Ответы ON ДанныеУчеников.ID = Ответы.УченикID) ON Задания.ID = Ответы.ЗаданиеID " +
                "WHERE(((ДанныеУчеников.Класс) = " + idKlass + ") AND((Задания.Предмет) = " + idSubject +")) " +
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


    }
}
