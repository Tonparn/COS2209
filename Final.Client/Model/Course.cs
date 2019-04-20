using System.Collections.Generic;

namespace Final.Client.Model
{
    internal class Course
    {
        public string CourseName;

        public IEnumerable<Lesson> Lesson;

        public string currentLesson;
    }

    internal class Lesson
    {
        public string Name;

        public string Chapter;

        public string Html;

        public string Editor;

        public string Hint;
    }
}
