using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CityList :List<City>
    {
        public CityList() { }
        public CityList( IEnumerable <City> lst): base(lst){}
        public CityList( IEnumerable <BaseEntity> lst): base(lst.Cast<City>().ToList()){}

    }
}
