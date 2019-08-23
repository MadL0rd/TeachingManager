using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace StartWindow.Data
{
    
public class TeacherUsr
    {
        public static int ID { get; set; }
        public static string Surname { get; set; }
        public static string Name { get; set; }
        public static string Patronymic { get; set; }
        public static int SchoolID { get; set; }
        public static string SchoolStr { get; set; }
        public static List<int> KlassID { get; set; }
        public static List<string> Klass { get; set; }
        public static List<int> SubjectsID { get; set; }
        public static List<string> Subjects { get; set; }
        public static System.Windows.Controls.Image Photo { get; set; }



        public static List<int> StringToListInt(string buff)
        {
            List<int> currentList = new List<int>();
            string substr = "";
            while (buff.Length > 0)
            {
                if (buff[0] >= '0' && buff[0] <= '9')
                {
                    substr += buff[0];
                    buff = buff.Substring(1);
                }
                else if (buff[0] == ';')
                {
                    currentList.Add(Convert.ToInt32(substr));
                    substr = "";
                    buff = buff.Substring(1);
                }
            }
            try
            {
                currentList.Add(Convert.ToInt32(substr));
                substr = "";
                buff = buff.Substring(1);
            }
            catch { }
            return currentList;
        }
        public static string GetTextWithID(string TableName, string columtName, int ID)
        {
            string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= "+ System.AppDomain.CurrentDomain.BaseDirectory + "\\AducationBase.accdb;";
            OleDbConnection connection = new OleDbConnection(connectString);
            string query = " SELECT [" + TableName + "]." + columtName +
                           " FROM[" + TableName + "]" +
                           " WHERE((([" + TableName + "].ID) = " + Convert.ToString(ID) + "));";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();

            string answer = command.ExecuteScalar().ToString();

            connection.Close();
            return answer;
        }
        public static int GetIDWithText(string TableName, string columtName, string Text)
        {
            string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= "+System.AppDomain.CurrentDomain.BaseDirectory+"\\AducationBase.accdb;";
            OleDbConnection connection = new OleDbConnection(connectString);
            string query = " SELECT [" + TableName + "].ID"+
                           " FROM[" + TableName + "]" +
                           " WHERE( ([" + TableName + "]."+ columtName +") = \"" + Text + "\");";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();

            int answer = (int)command.ExecuteScalar();

            connection.Close();
            return answer;
        }
        public static void GetTeacherUsr(string id)
        {
            string connectString = "provider=Microsoft.ACE.Oledb.12.0;Data Source= "+System.AppDomain.CurrentDomain.BaseDirectory+"\\AducationBase.accdb;";
            OleDbConnection connection = new OleDbConnection(connectString);
            string query = "SELECT Преподаватели.ID, Преподаватели.Фамилия, Преподаватели.Имя, Преподаватели.Отчество, Преподаватели.Школа, Преподаватели.Классы, Преподаватели.Предметы, Преподаватели.Фото FROM Преподаватели WHERE((Преподаватели.ID) = " + id + ");";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();
            OleDbDataReader dataReader = command.ExecuteReader();
            dataReader.Read();

            ID = (int)dataReader["ID"];
            Name = (string)dataReader["Имя"];
            Surname = (string)dataReader["Фамилия"];
            Patronymic = (string)dataReader["Отчество"];
            SchoolID = (int)dataReader["Школа"];
            KlassID = StringToListInt((string)dataReader["Классы"]);
            SubjectsID = StringToListInt((string)dataReader["Предметы"]);
            Klass = new List<string>();
            Subjects = new List<string>();

            for (int i = 0; i < KlassID.Count; i++)
            { 
                Klass.Add(GetTextWithID("Учебная программа", "Класс", KlassID[i]));
            }
            for (
                int i = 0; i < SubjectsID.Count; i++)
            {
                Subjects.Add(GetTextWithID("Список предметов", "Предмет", SubjectsID[i]));
            }
            connection.Close();
        }

    }
}
