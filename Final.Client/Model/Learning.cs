using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Client.Model
{
    public class Learning
    {
        public string CourseName;

        //Jupter notebook
        public string Jupyter;

        //Name of Course -- Show at footer 
        public string Lesson;

        //Lesson page -- Show at sidebar
        public string Html;

        //Flag current lesson
        public int Chapter;

        //Check if for render editor;
        public bool Editor;

        //Flag hint submit
        public bool HintFlag = false;

        //Hint -- Show both Html
        public string Hint; 

        public int maxLesson;
    }
}
