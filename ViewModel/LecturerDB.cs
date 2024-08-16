using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LecturerDB : PeopleDB
    {

        public string FirstName { get; set; }
        public Lecturer lecturer = new Lecturer();



        public override BaseEntity newEntity()
        {
            return new Lecturer(); //as BaseEntity;
        }
        public LecturerList SelectAll()
        {
            command.CommandText = "SELECT *,  PeopleTbl.Id AS ID FROM (PeopleTbl INNER JOIN LecturerTbl ON PeopleTbl.Id = LecturerTbl.Id); ";

            return new LecturerList(base.Select());
        }

        public LecturerList SelectByName(string firstName, string lastName)
        {
            if (String.IsNullOrEmpty(firstName))
                command.CommandText = "SELECT *,  PeopleTbl.ID AS ID FROM (PeopleTbl INNER JOIN LecturerTbl ON PeopleTbl.ID = LecturerTbl.Id) " +
                $"WHERE  lName = '{lastName}'";
            else if  ( String.IsNullOrEmpty(lastName))  
                    command.CommandText = "SELECT *,  PeopleTbl.ID AS ID FROM (PeopleTbl INNER JOIN LecturerTbl ON PeopleTbl.ID = LecturerTbl.Id) " +
                    $"WHERE  fName = '{firstName}'"; 
            else
                command.CommandText = "SELECT *,  PeopleTbl.ID AS ID FROM (PeopleTbl INNER JOIN LecturerTbl ON PeopleTbl.ID = LecturerTbl.Id) " +
                    $"WHERE fName = '{firstName}' AND lName = '{lastName}'";
            return new LecturerList(base.Select());
           
        }
        public LecturerList SelectByFirstName()
        {
            command.CommandText = "SELECT *,  PeopleTbl.ID AS ID FROM (PeopleTbl INNER JOIN StudentTbl ON PeopleTbl.ID = StudentTbl.Id) " +
            $"WHERE fName = '{this.FirstName}'";
            return new LecturerList(base.Select());
        }

        public LecturerList SelectByID(int id)
        {
            command.CommandText = "SELECT *, PeopleTbl.Id AS ID FROM (PeopleTbl INNER JOIN LecturerTbl ON PeopleTbl.Id = LecturerTbl.Id) " +
                $"WHERE PeopleTbl.ID = '{id}'";
            return new LecturerList(base.Select());
        }

        public void CreateModel(Lecturer lecturer )
        {
            base.CreateModel(lecturer);

        }

        public int CreateInsertSql(Lecturer lecturer)
        {
            string sqlStr = $"INSERT INTO PeopleTbl (fName, lName, city,  phone) VALUES('{lecturer.Fname}', '{lecturer.Lname}', {lecturer.City.Id}, {lecturer.Phone})";
            int lecturer_Id = base.SaveChanges(sqlStr);
            string sqlStr2 = $"INSERT INTO  LecturerTbl (Id) VALUES ({lecturer_Id})";
            return base.SaveChanges(sqlStr2);
        }

        public int CreateDeletetSql(Lecturer lecturer)
        {
            string sqlStr;


            sqlStr = $"DELETE TOP(1) FROM LecturerTbl WHERE Id = {lecturer.Id};";
            base.SaveChanges(sqlStr);
            sqlStr = $"DELETE TOP(1) FROM PeopleTbl WHERE Id = {lecturer.Id}; ";
            return base.SaveChanges(sqlStr);
        }
        public int CreateUpdateSql(Lecturer lecturer)
        {
            string sqlStr;
            sqlStr = $"UPDATE  PeopleTbl SET fName = '{lecturer.Fname}' , lname = '{lecturer.Lname}', city ={lecturer.City.Id} ,  phone = {lecturer.Phone}" +
                $"WHERE Id = {lecturer.Id} ;";
            return base.SaveChanges(sqlStr);

        }

    }
}
