using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalC_Quize.models
{
    public class Subject
    {
        public string Name { get; set; }
        public Exam Exam { get; set; }

        public Subject(string name, Exam exam)
        {
            Name = name;
            Exam = exam;
        }

        public override string ToString()
        {
            return $"Subject: {Name}, Exam: {Exam}";
        }
    }

}
