using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LecturerList : List<Lecturer>
    {
        public LecturerList() { }
        public LecturerList(IEnumerable<Lecturer> lst) : base(lst) { }
        public LecturerList(IEnumerable<BaseEntity> lst) : base(lst.Cast<Lecturer>().ToList()) { }
    }
}
