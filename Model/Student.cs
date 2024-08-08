using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Student :People
    {
        private LessonList lessonList;

        public LessonList FinishedCourses
        {
            get
            {
                List<Lesson> lst = this.lessonList.FindAll(lesson => lesson.Grade > 55).ToList();
                return new LessonList(lst);
            }
        }
    }
}