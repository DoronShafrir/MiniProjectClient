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
using System.CodeDom;

namespace ViewModel
{
    public class StudentDB : PeopleDB
    { 
        public string FirstName { get; set; }
        public Student student = new Student();

        public StudentDB()
        {
            FirstName = "Doron";
        }

        

        public override BaseEntity newEntity()
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


       

        public  int CreateInsertSql(Student student)
        {
            string sqlStr = $"INSERT INTO PeopleTbl (fName, lName, city,  phone) VALUES('{student.Fname}', '{student.Lname}', {student.City.Id}, {student.Phone})";         
            int Student_Id =  base.SaveChanges(sqlStr);
            string sqlStr2 = $"INSERT INTO  StudentTbl (Id) VALUES ({Student_Id})";
            return base.SaveChanges(sqlStr2);
        }

        public int CreateDeletetSql(Student student)
        {
            string sqlStr;
            

            sqlStr = $"DELETE TOP(1) FROM StudentTbl WHERE Id = {student.Id};";
            base.SaveChanges(sqlStr);
            sqlStr = $"DELETE TOP(1) FROM PeopleTbl WHERE Id = {student.Id}; ";
            return base.SaveChanges(sqlStr);
        }
        public int CreateUpdateSql(Student student)
        {
            string sqlStr;
            sqlStr = $"UPDATE  PeopleTbl SET fName = '{student.Fname}' , lname = '{student.Lname}', city ={student.City.Id} ,  phone = {student.Phone}" +
                $"WHERE Id = {student.Id} ;";
            return base.SaveChanges(sqlStr);
            
        }

        public override void CreateLocalModel(BaseEntity entity)
        {
            
        }
    }
}  


        

       
