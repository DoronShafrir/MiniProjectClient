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
        
        
        protected override BaseEntity newEntity()
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

        public LecturerList SelectByID(int id)
        {
            command.CommandText = "SELECT *, PeopleTbl.Id AS ID FROM (PeopleTbl INNER JOIN LecturerTbl ON PeopleTbl.Id = LecturerTbl.Id) " +
                $"WHERE PeopleTbl.ID = '{id}'";
            return new LecturerList(base.Select());
        }

    }
}
