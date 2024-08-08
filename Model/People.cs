using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class People :BaseEntity
    {
        private string fname;
        private string lname;
        private City city;
        private int phone;

        
        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public City City { get => city; set => city = value; }

        public int Phone { get => phone; set => phone = value; }
    }
}
