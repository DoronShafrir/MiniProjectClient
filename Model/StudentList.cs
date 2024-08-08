using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StudentList :List<Student>
    {
        public StudentList() { }
        public StudentList( IEnumerable <Student> lst): base(lst){}
        public StudentList( IEnumerable <BaseEntity> lst): base(lst.Cast<Student>().ToList()){}

    }

   
}
