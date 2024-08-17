using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Lecturer : People
    {
        private LessonList lessonList;

        public string Department {get; set;}

        public LessonList TeachingCourses
        {
            get
            {
                List<Lesson> lst = this.lessonList.FindAll(lesson => lesson.Grade > 55).ToList();
                return new LessonList(lst);
            }
        }
    }
}

