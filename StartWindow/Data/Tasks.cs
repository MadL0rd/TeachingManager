using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Media;
using System.Windows.Controls;

namespace StartWindow.Data
{
   
    public class IDWithText
    {
        public int ID { get; set; }
        public String Text { get; set; }
    }
    public class TaskFileImage
    {
        public string directory { get; set; }
        public Image image { get; set; }
        public ImageSource IMGS { get; set; }

        public TaskFileImage(string dirBuff)
        {
            directory = dirBuff;
            ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
            image = new Image();
            image.SetValue(System.Windows.Controls.Image.SourceProperty, imageSourceConverter.ConvertFromString(directory));
            IMGS = image.Source;
        }

    }
    public static class NewTask
    {
        public static int TeacherID { get; set; }
        public static string Title { get; set; }
        public static DateTime DateEnd { get; set; }
        public static int SchoolID { get; set; }
        public static int KlassID { get; set; }
        public static string Klass { get; set; }
        public static int SubjectID { get; set; }
        public static string Subject { get; set; }
        public static string TaskText { get; set; }
        public static List<TaskFileImage> TaskFiles { get; set; } = new List<TaskFileImage>();

    }
    public static class NewTaskAnswer
    {
        public static int TeacherID { get; set; } = -1;
        public static int StudentID { get; set; } = -1;
        public static int TaskID { get; set; } = -1;
        public static string AnswerText { get; set; } = "";
        public static List<TaskFileImage> AnswerFiles { get; set; } = new List<TaskFileImage>();

        public static bool UnloadAnswer()
        {
            if (!(TeacherID!= -1&& StudentID != -1 && TaskID != -1 && AnswerText!= ""))
            {
                return false;
            }

            string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= "+System.AppDomain.CurrentDomain.BaseDirectory+"\\AducationBase.accdb;";
            OleDbConnection connection = new OleDbConnection(connectString);
            string query = " SELECT Ответы.ID " +
                " FROM Ответы " +
                " WHERE( ((Ответы.ЗаданиеID) = "+TaskID + " ) AND ( (Ответы.УченикID) = " + StudentID + " ));";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();
            string answerID = "";
            try
            {
                answerID = command.ExecuteScalar().ToString();
            }
            catch 
            {}
           
            if (answerID != "")
            {
                query = "DELETE Ответы.ID" +
                    " FROM Ответы" +
                    " WHERE((Ответы.ID) = "+answerID+");";
                command = new OleDbCommand(query, connection);
                command.ExecuteScalar();
            }
            connection.Close();

            if (AnswerFiles.Count > 0)
            { 
                string Date = Convert.ToString(DateTime.Today.ToString("dd.MM.yyyy"));
                query = "INSERT INTO Ответы(ЗаданиеID, УчительID, УченикID, Дата, ТекстОтвета, ДопФайлы) " +
                    "values( '" + TaskID + "', '" + TeacherID + "', '" + StudentID + "', '" + Date + "', '" + AnswerText + "' , ? )";
                if (answerID == "")
                {

                }

                command = new OleDbCommand(query, connection);

                OleDbParameter oleDbParameter = new OleDbParameter("ДопФайлы", OleDbType.VarBinary);
                string fileName = AnswerFiles[0].directory;                                                    //Путь к файлу
                System.Drawing.Image image = System.Drawing.Image.FromFile(fileName);                                                 //Изображение из файла.
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();                                                                       //Поток в который запишем изображение
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
                string Date = Convert.ToString(DateTime.Today.ToString("dd.MM.yyyy"));
                query = "INSERT INTO Ответы(ЗаданиеID, УчительID, УченикID, Дата, ТекстОтвета) " +
                    "values( '" + TaskID + "', '" + TeacherID + "', '" + StudentID + "', '" + Date + "', '" + AnswerText + "' )";
                command = new OleDbCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }


            return true;
        }

    }

    class Answer
    {
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public string TeacherFIO { get; set; } = "";
        public int StudentID { get; set; }
        public string StudentFIO { get; set; } = "";
        public int TaskID { get; set; }
        public DateTime Date { get; set; }
        public string DateStr { get; set; }
        public string AnswerText { get; set; }
        public Image AnswerImage { get; set; }
        public ImageSource IMGS { get; set; }
        public string Mark { get; set; }
        public string Comment { get; set; }

        public void GetFIO()
        {
            string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= "+System.AppDomain.CurrentDomain.BaseDirectory+"\\AducationBase.accdb;";
            OleDbConnection connection = new OleDbConnection(connectString);
            string query = "SELECT ДанныеУчеников.Фамилия, ДанныеУчеников.Имя, ДанныеУчеников.Отчество" +
                " FROM ДанныеУчеников WHERE(((ДанныеУчеников.ID) = " + StudentID + " ));";

            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();
            OleDbDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                StudentFIO += (string)dataReader["Имя"] + " " + (string)dataReader["Отчество"] + " " + (string)dataReader["Фамилия"];
            }
            query = "SELECT Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество" +
                " FROM Преподаватели WHERE(((Преподаватели.ID) = " + TeacherID + " ));";
            command = new OleDbCommand(query, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                TeacherFIO += (string)dataReader["Имя"] + " " + (string)dataReader["Отчество"] + " " + (string)dataReader["Фамилия"];
            }
            connection.Close();
        }

        public static List<Answer> GetAnswers()
        {
            Tasks buff = ViewModel.TasksViewModel.CurrentTask;
            string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= "+System.AppDomain.CurrentDomain.BaseDirectory+"\\AducationBase.accdb;";
            OleDbConnection connection = new OleDbConnection(connectString);
            string query = "SELECT Ответы.ID, Ответы.ЗаданиеID, Ответы.УчительID, Ответы.УченикID, Ответы.Дата, Ответы.ТекстОтвета, Ответы.ДопФайлы, Ответы.Оценка, Ответы.Комментарий" +
                " FROM Ответы WHERE( ((Ответы.ЗаданиеID) = " + buff.ID + " ) AND((Ответы.УчительID) = " + Data.TeacherUsr.ID + " ) );";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();
            OleDbDataReader dataReader = command.ExecuteReader();
            List<Answer> result = new List<Answer>();
            System.IO.Directory.CreateDirectory("ImageBuffFolder");
            while (dataReader.Read())
            {
                try
                {
                    Answer buffAnswer = new Answer();
                    buffAnswer.ID = (int)dataReader["ID"];
                    buffAnswer.TeacherID = (int)dataReader["УчительID"];
                    buffAnswer.StudentID = (int)dataReader["УченикID"];
                    buffAnswer.TaskID = (int)dataReader["ЗаданиеID"];
                    buffAnswer.Date = (DateTime)dataReader["Дата"];
                    buffAnswer.DateStr = ((DateTime)(dataReader["Дата"])).ToLongDateString();
                    buffAnswer.AnswerText = (string)dataReader["ТекстОтвета"];
                    try
                    {
                        buffAnswer.Mark = (string)dataReader["Оценка"];
                    }
                    catch
                    {
                        buffAnswer.Mark = "Не оценено";
                    }
                    try
                    {
                        buffAnswer.Comment = (string)dataReader["Комментарий"];
                    }
                    catch
                    {
                        buffAnswer.Comment = "";
                    }
                    buffAnswer.GetFIO();
                    try
                    {
                        System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                        memoryStream.Write((byte[])dataReader["ДопФайлы"], 0, ((byte[])dataReader["ДопФайлы"]).Length);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
                        image.Save(@"ImageBuffFolder\" + buffAnswer.ID + "answ.BMP");
                        memoryStream.Dispose();
                        ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                        buffAnswer.AnswerImage = new Image();
                        buffAnswer.AnswerImage.SetValue(System.Windows.Controls.Image.SourceProperty, imageSourceConverter.ConvertFromString(@"ImageBuffFolder\" + buffAnswer.ID + "answ.BMP"));
                        buffAnswer.IMGS = buffAnswer.AnswerImage.Source;
                    }
                    catch { }
                    result.Add(buffAnswer);
                }
                catch { }
            }
            try
            {
                NewTaskAnswer.TaskID = result[0].ID;
            }
            catch
            {
                NewTaskAnswer.TaskID = -1;
            }
            return result;


        }

        public void MarkTheAnswer(string mark, string comment)
        {
            Mark = mark;
            Comment = comment;
            string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= "+System.AppDomain.CurrentDomain.BaseDirectory+"\\AducationBase.accdb;";
            OleDbConnection connection = new OleDbConnection(connectString);
            string query = "UPDATE Ответы SET Ответы.Оценка = \"" + mark + "\", Ответы.Комментарий = \"" + comment + "\" WHERE((Ответы.ID) = " + ID + ");";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    class Tasks
    {
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public string Title { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public string DateBeginStr { get; set; }
        public string DateEndStr { get; set; }
        public int SchoolID { get; set; }
        public int KlassID { get; set; }
        public string Klass { get; set; }
        public int SubjectID { get; set; }
        public string Subject { get; set; }
        public string TaskText { get; set; }
        public object ImageBuff { get; set; }
        public Image TaskImage { get; set; }
        public ImageSource IMGS { get; set; }

        public static List<Tasks> GetTasks()
        {
            string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= "+System.AppDomain.CurrentDomain.BaseDirectory+"\\AducationBase.accdb;";
            OleDbConnection connection = new OleDbConnection(connectString);
            string query = "SELECT Задания.ID, Задания.Преподаватель, Задания.Тема, Задания.[Дата выдачи], Задания.[Дата сдачи], Задания.Школа, Задания.Класс, Задания.Предмет, Задания.[Текст задания], Задания.ДопФайлы FROM Задания ORDER BY Задания.[Дата выдачи] DESC ;";
            OleDbCommand comand = new OleDbCommand(query, connection);
            connection.Open();
            OleDbDataReader dataReader = comand.ExecuteReader();
            List<Tasks> result = new List<Tasks>();
            System.IO.Directory.CreateDirectory("ImageBuffFolder");
            while (dataReader.Read())
            {
                try
                {
                    result.Add
                    (new Tasks
                    {
                        ID = (int)dataReader["ID"],
                        TeacherID = (int)dataReader["Преподаватель"],
                        Title = (string)dataReader["Тема"],
                        DateBegin = (DateTime)dataReader["Дата выдачи"],
                        DateEnd = (DateTime)dataReader["Дата сдачи"],
                        DateBeginStr = ((DateTime)(dataReader["Дата выдачи"])).ToLongDateString(),
                        DateEndStr = ((DateTime)dataReader["Дата сдачи"]).ToLongDateString(),
                        SchoolID = (int)dataReader["Школа"],
                        KlassID = (int)dataReader["Класс"],
                        Klass = StartWindow.Data.TeacherUsr.GetTextWithID("Учебная программа", "Класс", (int)dataReader["Класс"]),
                        SubjectID = (int)dataReader["Предмет"],
                        Subject = StartWindow.Data.TeacherUsr.GetTextWithID("Список предметов", "Предмет", (int)dataReader["Предмет"]),
                        TaskText = (string)dataReader["Текст задания"],
                    });
                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                    memoryStream.Write((byte[])dataReader["ДопФайлы"], 0, ((byte[])dataReader["ДопФайлы"]).Length);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
                    image.Save(@"ImageBuffFolder\" +result[result.Count - 1].ID+".BMP");
                    memoryStream.Dispose();
                    ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                    result[result.Count - 1].TaskImage = new Image();
                    result[result.Count - 1].TaskImage.SetValue(System.Windows.Controls.Image.SourceProperty, imageSourceConverter.ConvertFromString(@"ImageBuffFolder\" + result[result.Count - 1].ID + ".BMP"));
                    result[result.Count - 1].IMGS = result[result.Count - 1].TaskImage.Source;
                }
                catch { }
            }
            try
            {
                NewTaskAnswer.TaskID = result[0].ID;
            }
            catch
            {
                NewTaskAnswer.TaskID = -1;
            }
            return result;
        }

    }


    public static class CurrentTask
    {
        private static List<Tasks> currentTaskList = new List<Tasks>();
    }
}
