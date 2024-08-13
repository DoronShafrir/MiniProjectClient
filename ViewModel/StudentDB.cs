using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Windows.Input;

namespace ViewModel
{
    public class StudentDB : PeopleDB
    { 
        public string FirstName { get; set; }

        public StudentDB()
        {
            FirstName = "Doron";
        }

        //{
        //    private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\DSH\Doron\sources\repos\MiniProject\ViewModel\MiniProj.mdf;Integrated Security=True";
        //    private SqlConnection connection;
        //    private SqlCommand command;
        //    private SqlDataReader reader;

        //    public StudentDB()
        //    {
        //        connection = new SqlConnection(connectionString);
        //        command = new SqlCommand();
        //        command.Connection = this.connection;
        //    }

        protected override BaseEntity newEntity()
    {
        return new Student(); //as BaseEntity;
    }

        public StudentList SelectAll()
        {
            command.CommandText = "SELECT *,  PeopleTbl.Id AS ID FROM (PeopleTbl INNER JOIN StudentTbl ON PeopleTbl.Id = StudentTbl.Id); ";
           
            return new StudentList(base.Select());
        }

        public StudentList SelectByName(string firstName, string lastName)
        {
            if (String.IsNullOrEmpty(firstName))
                command.CommandText = "SELECT *,  PeopleTbl.ID AS ID FROM (PeopleTbl INNER JOIN StudentTbl ON PeopleTbl.ID = StudentTbl.Id) " +
                $"WHERE lName = '{lastName}'";
            else if (String.IsNullOrEmpty(lastName))
                command.CommandText = "SELECT *,  PeopleTbl.ID AS ID FROM (PeopleTbl INNER JOIN StudentTbl ON PeopleTbl.ID = StudentTbl.Id) " +
                $"WHERE fName = '{firstName}' ";
            else
                command.CommandText = "SELECT *,  PeopleTbl.ID AS ID FROM (PeopleTbl INNER JOIN StudentTbl ON PeopleTbl.ID = StudentTbl.Id) " +
                $"WHERE fName = '{firstName}' AND lName = '{lastName}'";
            return new StudentList(base.Select());

        }
        public StudentList SelectByFirstName()
        {
                command.CommandText = "SELECT *,  PeopleTbl.ID AS ID FROM (PeopleTbl INNER JOIN StudentTbl ON PeopleTbl.ID = StudentTbl.Id) " +
                $"WHERE fName = '{this.FirstName}'";
            return new StudentList(base.Select());
        }

            public StudentList SelectByID(int id)
        {
            command.CommandText = "SELECT *, PeopleTbl.Id AS ID FROM (PeopleTbl INNER JOIN StudentTbl ON PeopleTbl.Id = StudentTbl.Id) " +
                $"WHERE PeopleTbl.ID = '{id}'";
            return new StudentList(base.Select());
        }

        //public StudentList Select()
        //{
        //    StudentList studentList = new StudentList();
        //    try
        //    {
        //        command.Connection = connection;
        //        connection.Open();
        //        reader = command.ExecuteReader();
        //        Student student;
        //        while (reader.Read())
        //        {
                    //student = new Student();
                    //student.Id = (int)reader["ID"];
                    //student.Fname = reader["FirstName"].ToString();
                    //student.Lname = reader["LastName"].ToString();
                    //student.Phone = (int)reader["Telephone"];
                    //int city = (int)reader["City"];
                    //student.City = CityDB.SelectByID(city);
        //            studentList.Add(CreateModel(student, CityDB));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        if (reader != null)
        //            reader.Close();
        //        if (connection.State == ConnectionState.Open)
        //            connection.Close();
        //    }
        //    return studentList;
        //}
        public  void CreateModel(Student student)
        {
            base.CreateModel(student);
            //student.Id = (int)reader["ID"];
            //student.Fname = reader["FirstName"].ToString();
            //student.Lname = reader["LastName"].ToString();
            //student.Phone = (int)reader["Telephone"];
            //int city = (int)reader["City"];
            //student.City = CityDB.SelectById(city);
            //return student;
        }
    }
}  


        

       
