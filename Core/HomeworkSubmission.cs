using System.Collections.Generic;
using System.IO;

namespace Submitotron.Core
{
    public class HomeworkSubmission
    {
        public string StudentID {get; set;}
        public string HomeworkID {get; set;}
        public List<HomeworkFile> Files {get; set;} = new List<HomeworkFile>();

    }
}