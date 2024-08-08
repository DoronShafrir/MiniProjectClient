using Model;
using System.Xml.Linq;

namespace ViewModel
{
    public abstract class PeopleDB: BaseDB
    {
        public override void CreateModel(BaseEntity entity)
        {
            People people = entity as People;
            people.Id = (int)reader["Id"];
            people.Fname = reader["fName"].ToString();
            people.Lname = reader["lName"].ToString();
            people.Phone = (int)reader["phone"];
            int city = (int)reader["city"];
            people.City = CityDB.SelectById(city);




        }
    }
}