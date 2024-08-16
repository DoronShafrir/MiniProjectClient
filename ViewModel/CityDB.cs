using Model;
using System.Data;
using System.Data.SqlClient;

namespace ViewModel
{
    public  class CityDB  : BaseDB
    {
        private static CityList list = null;

        public override BaseEntity newEntity()
        {
            return new City();  
        }

        public static City SelectById(int id)
        {
            if (list == null)
            {
                CityDB db = new CityDB();
                list = db.SelectAll();
            }
            City city = list.Find(item => item.Id == id);
            return city;
        }

        public CityList SelectAll()
        {
            command.CommandText = "SELECT * FROM CityTbl";
            return new CityList(base.Select());
        }
        

        public override void CreateModel(BaseEntity entity)
        {
            City city = entity as City;
            city.Id = (int)reader["Id"];
            city.Name = reader["cityName"].ToString();
        }

        
    }
}