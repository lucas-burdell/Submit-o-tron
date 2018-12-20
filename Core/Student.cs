using System.Collections.Generic;

namespace Submitotron.Core
{
    public class Student
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public List<HomeworkSubmission> SubmittedWorks { get; set; }
        public List<Homework> AssignedWorks { get; set; }
    }
}